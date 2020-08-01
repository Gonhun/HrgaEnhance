using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HrgaEnhance.Models
{
    public class ClsUploadAbsen
    {
        public IQueryable<lembarkerja> getAbsen(String s_Nrp, String s_Awal, string s_Akhir)
        {
            LtsAbsenDataContext dataContext = new LtsAbsenDataContext();
            if(s_Nrp is null || s_Awal is null || s_Akhir is null)
            {
                return dataContext.lembarkerjas.Where(j => j.nrp.Equals(""));
            }
            else
            {
                return dataContext.lembarkerjas
                    .Where(j => j.nrp.Equals(s_Nrp) && (j.tanggal >= Convert.ToDateTime(s_Awal) && j.tanggal <= Convert.ToDateTime(s_Akhir)))
                    .OrderByDescending(i => i.tanggal);
            }

        }

        public IQueryable<AbsentCode> getAbsenCode()
        {
            LtsAbsenDataContext dataContext = new LtsAbsenDataContext();
            return dataContext.AbsentCodes.Distinct().Where(j => j.Code != null);
        }

        public bool updateAbsen(ClsParameter.Absen sParameter, string iStrSessNrp)
        {
            try
            {
                LtsAbsenDataContext dataContext = new LtsAbsenDataContext();
                lembarkerja iTbl = dataContext.lembarkerjas.Where(k => k.nrp.Equals(sParameter.nrp) && k.tanggal.Equals(sParameter.tanggal)).FirstOrDefault();

                iTbl.@in = sParameter.@in;
                iTbl.@out = sParameter.@out;
                iTbl.Absent = sParameter.Absent;
                iTbl.RosterCode = sParameter.RosterCode;
                iTbl.SKL = sParameter.SKL;

                tblinjekdept1 iTblTemp = new tblinjekdept1();
                iTblTemp.nrp = sParameter.nrp;
                iTblTemp.tanggal = sParameter.tanggal;
                iTblTemp.shift = sParameter.Shift;
                iTblTemp.@in = sParameter.@in;
                iTblTemp.@out = sParameter.@out;
                iTblTemp.Keterangan = sParameter.Keterangan;
                iTblTemp.revisiby = iStrSessNrp;
                iTblTemp.tglrevisi = System.DateTime.Now;

                lembarkerja_BACKUP iTblBackup = new lembarkerja_BACKUP();
                iTblBackup.id = iTbl.id;
                iTblBackup.nrp = iTbl.nrp;
                iTblBackup.tanggal = iTbl.tanggal;
                iTblBackup.shift = iTbl.shift;
                iTblBackup.Absent = iTbl.Absent;
                iTblBackup.@in = iTbl.@in;
                iTblBackup.@out = iTbl.@out;
                iTblBackup.SKL = iTbl.SKL;
                iTblBackup.InputBY = "System Backup";
                iTblBackup.TGLINPUT = System.DateTime.Now;

                dataContext.SubmitChanges();
                dataContext.Dispose();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public DataTable ProcessCSV(string fileName, string sSessUpload, string iStrSessNRP)
        {
            //Set up our variables
            string Feedback = string.Empty;
            string line = string.Empty;
            string[] strArray;
            List<string> strList;

            DataTable dt = new DataTable();
            DataRow row;
            // work out where we should split on comma, but not in a sentence
            Regex r = new Regex(";(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            //Regex r = new Regex("|");
            //Set the filename in to our stream
            StreamReader sr = new StreamReader(fileName);

            //Read the first line and split the string at , with our regular expression in to an array
            line = sr.ReadLine();
            strList = r.Split(line).ToList();
            //strList = line.Split(';').ToList();
            strList.Insert(0, "CREATED_DATE");
            strList.Insert(0, "CREATED_BY");
            strList.Insert(0, "SESSION_UPLOAD");

            //strList.Add("REMARKS");
            //strArray = r.Split(line);
            strArray = strList.ToArray();

            //For each item in the new split array, dynamically builds our Data columns. Save us having to worry about it.
            Array.ForEach(strArray, s => dt.Columns.Add(new DataColumn()));

            //Read each line in the CVS file until it’s empty
            while ((line = sr.ReadLine()) != null)
            {
                row = dt.NewRow();

                //add our current value to our data row
                line = string.Format("{0};{1};{2};{3}", sSessUpload, iStrSessNRP, System.DateTime.Now, line);
                row.ItemArray = r.Split(line);
                //row.ItemArray = line.Split(';');
                //row.ItemArray[8] = db_learn.TBL_M_PESERTAs.Where(f => f.NRP.Equals(row.ItemArray[2])).Select(f => f.DSTRCT_CODE).FirstOrDefault();
                dt.Rows.Add(row);
            }

            //Tidy Streameader up
            sr.Dispose();
            //return a the new DataTable
            return dt;
        }

        public String ProcessBulkCopy(DataTable dt, string sConnetionString, string sTblTempName)
        {
            string Feedback = string.Empty;
            string connString = ConfigurationManager.ConnectionStrings[sConnetionString].ConnectionString;

            //make our connection and dispose at the end
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //make our command and dispose at the end
                using (var copy = new SqlBulkCopy(conn))
                {
                    //Open our connection
                    conn.Open();
                    ///Set target table and tell the number of rows
                    copy.DestinationTableName = sTblTempName;
                    copy.BatchSize = dt.Rows.Count;
                    try
                    {
                        //Send it to the server
                        copy.WriteToServer(dt);
                        Feedback = "Upload complete";
                    }
                    catch (Exception ex)
                    {
                        Feedback = ex.Message;
                    }
                }
            }
            return Feedback;
        }

    }
}