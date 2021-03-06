﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HrgaEnhance.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PERSIS")]
	public partial class LtsShareDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public LtsShareDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["PERSISConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LtsShareDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LtsShareDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LtsShareDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LtsShareDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<VW_R_EMPLOYEE_SHARE> VW_R_EMPLOYEE_SHAREs
		{
			get
			{
				return this.GetTable<VW_R_EMPLOYEE_SHARE>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_R_EMPLOYEE_SHARE")]
	public partial class VW_R_EMPLOYEE_SHARE
	{
		
		private string _EMPLOYEE_ID;
		
		private string _FIRST_NAME;
		
		private string _SURNAME;
		
		private string _NAME;
		
		private string _POSITION_ID;
		
		private string _POS_TITLE;
		
		private string _CHANGE_REASON;
		
		private string _CHANGE_REASON_DESC;
		
		private string _DSTRCT_CODE;
		
		private string _WORK_LOC;
		
		private string _WORK_LOC_DESC;
		
		private string _EMP_STATUS;
		
		private string _EMP_STATUS_DESC;
		
		private string _GENDER_CODE;
		
		private string _GENDER_DESC;
		
		private string _EMP_TYPE;
		
		private string _EMP_TYPE_DESC;
		
		private string _STAFF_CATEG;
		
		private string _STAFF_CATEG_DESC;
		
		private string _BIRTH_DATE;
		
		private string _HIRE_DATE;
		
		private string _SERVICE_DATE;
		
		private string _TERMINATION_DATE;
		
		private string _STATUS_HIRE;
		
		private string _STATUS_HIRE_DESC;
		
		private string _POINT_OF_HIRE;
		
		private string _POINT_OF_HIRE_DESC;
		
		private string _ACCOUNT_DOMAIN;
		
		private string _NRP;
		
		private System.Nullable<int> _AGE;
		
		private string _BLOOD_TYPE;
		
		private string _RELIGION_DESC;
		
		private string _RES_ADDRESS_1;
		
		private string _RES_ADDRESS_2;
		
		private string _RES_ADDRESS_3;
		
		private string _RES_ZIPCODE;
		
		private string _SUPERIOR_ID;
		
		private string _POSITION_START_DATE;
		
		private string _GOLONGAN;
		
		private string _GOL_COMPTCY_LEVEL;
		
		private string _GOL_START_DATE;
		
		private string _HOME_PHONE_NO;
		
		private string _HOME_MOBILE_NO;
		
		private string _RANKS;
		
		private string _RANK_DESC;
		
		private string _RANK_START_DATE;
		
		private string _DEPT_CODE;
		
		private string _DEPT_DESC;
		
		private string _DEPT_CODE_DESC;
		
		private string _DIV_CODE;
		
		private string _DIV_DESC;
		
		private string _DIV_CODE_DESC;
		
		private string _Address_LotusNotes;
		
		private string _Email_Internet;
		
		private System.Nullable<int> _ACTIVE_STATUS;
		
		private string _GENDER;
		
		private string _NAME_INITCAP;
		
		private string _RELIGION;
		
		private System.Nullable<System.DateTime> _MODIFIED_DATE;
		
		private string _RANKS_DESC;
		
		private string _RANKS_START_DATE;
		
		private string _SECONDARY_POSITION_ID;
		
		private string _LAST_EDUCATION;
		
		private string _BIRTH_PLACE;
		
		private string _BIRTH_PLACE_DESC;
		
		private string _GROUP_GOLONGAN;
		
		private string _MARITAL_STATUS;
		
		private string _MARITAL_STATUS_DESC;
		
		private string _HCGS_CONV;
		
		private string _KELAS_KAMAR;
		
		private System.Nullable<double> _TARIF;
		
		private string _KELAS_PESAWAT;
		
		private string _MARITAL_CODE;
		
		public VW_R_EMPLOYEE_SHARE()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMPLOYEE_ID", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string EMPLOYEE_ID
		{
			get
			{
				return this._EMPLOYEE_ID;
			}
			set
			{
				if ((this._EMPLOYEE_ID != value))
				{
					this._EMPLOYEE_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FIRST_NAME", DbType="VarChar(12)")]
		public string FIRST_NAME
		{
			get
			{
				return this._FIRST_NAME;
			}
			set
			{
				if ((this._FIRST_NAME != value))
				{
					this._FIRST_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SURNAME", DbType="VarChar(30)")]
		public string SURNAME
		{
			get
			{
				return this._SURNAME;
			}
			set
			{
				if ((this._SURNAME != value))
				{
					this._SURNAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NAME", DbType="VarChar(43)")]
		public string NAME
		{
			get
			{
				return this._NAME;
			}
			set
			{
				if ((this._NAME != value))
				{
					this._NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_POSITION_ID", DbType="VarChar(10)")]
		public string POSITION_ID
		{
			get
			{
				return this._POSITION_ID;
			}
			set
			{
				if ((this._POSITION_ID != value))
				{
					this._POSITION_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_POS_TITLE", DbType="VarChar(40)")]
		public string POS_TITLE
		{
			get
			{
				return this._POS_TITLE;
			}
			set
			{
				if ((this._POS_TITLE != value))
				{
					this._POS_TITLE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CHANGE_REASON", DbType="VarChar(2)")]
		public string CHANGE_REASON
		{
			get
			{
				return this._CHANGE_REASON;
			}
			set
			{
				if ((this._CHANGE_REASON != value))
				{
					this._CHANGE_REASON = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CHANGE_REASON_DESC", DbType="VarChar(50)")]
		public string CHANGE_REASON_DESC
		{
			get
			{
				return this._CHANGE_REASON_DESC;
			}
			set
			{
				if ((this._CHANGE_REASON_DESC != value))
				{
					this._CHANGE_REASON_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DSTRCT_CODE", DbType="VarChar(4)")]
		public string DSTRCT_CODE
		{
			get
			{
				return this._DSTRCT_CODE;
			}
			set
			{
				if ((this._DSTRCT_CODE != value))
				{
					this._DSTRCT_CODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WORK_LOC", DbType="VarChar(5)")]
		public string WORK_LOC
		{
			get
			{
				return this._WORK_LOC;
			}
			set
			{
				if ((this._WORK_LOC != value))
				{
					this._WORK_LOC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WORK_LOC_DESC", DbType="VarChar(50)")]
		public string WORK_LOC_DESC
		{
			get
			{
				return this._WORK_LOC_DESC;
			}
			set
			{
				if ((this._WORK_LOC_DESC != value))
				{
					this._WORK_LOC_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMP_STATUS", DbType="VarChar(1)")]
		public string EMP_STATUS
		{
			get
			{
				return this._EMP_STATUS;
			}
			set
			{
				if ((this._EMP_STATUS != value))
				{
					this._EMP_STATUS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMP_STATUS_DESC", DbType="VarChar(25)")]
		public string EMP_STATUS_DESC
		{
			get
			{
				return this._EMP_STATUS_DESC;
			}
			set
			{
				if ((this._EMP_STATUS_DESC != value))
				{
					this._EMP_STATUS_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GENDER_CODE", DbType="VarChar(1)")]
		public string GENDER_CODE
		{
			get
			{
				return this._GENDER_CODE;
			}
			set
			{
				if ((this._GENDER_CODE != value))
				{
					this._GENDER_CODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GENDER_DESC", DbType="VarChar(7)")]
		public string GENDER_DESC
		{
			get
			{
				return this._GENDER_DESC;
			}
			set
			{
				if ((this._GENDER_DESC != value))
				{
					this._GENDER_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMP_TYPE", DbType="VarChar(3)")]
		public string EMP_TYPE
		{
			get
			{
				return this._EMP_TYPE;
			}
			set
			{
				if ((this._EMP_TYPE != value))
				{
					this._EMP_TYPE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMP_TYPE_DESC", DbType="VarChar(50)")]
		public string EMP_TYPE_DESC
		{
			get
			{
				return this._EMP_TYPE_DESC;
			}
			set
			{
				if ((this._EMP_TYPE_DESC != value))
				{
					this._EMP_TYPE_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_CATEG", DbType="VarChar(3)")]
		public string STAFF_CATEG
		{
			get
			{
				return this._STAFF_CATEG;
			}
			set
			{
				if ((this._STAFF_CATEG != value))
				{
					this._STAFF_CATEG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_CATEG_DESC", DbType="VarChar(50)")]
		public string STAFF_CATEG_DESC
		{
			get
			{
				return this._STAFF_CATEG_DESC;
			}
			set
			{
				if ((this._STAFF_CATEG_DESC != value))
				{
					this._STAFF_CATEG_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BIRTH_DATE", DbType="VarChar(8)")]
		public string BIRTH_DATE
		{
			get
			{
				return this._BIRTH_DATE;
			}
			set
			{
				if ((this._BIRTH_DATE != value))
				{
					this._BIRTH_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HIRE_DATE", DbType="VarChar(8)")]
		public string HIRE_DATE
		{
			get
			{
				return this._HIRE_DATE;
			}
			set
			{
				if ((this._HIRE_DATE != value))
				{
					this._HIRE_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SERVICE_DATE", DbType="VarChar(8)")]
		public string SERVICE_DATE
		{
			get
			{
				return this._SERVICE_DATE;
			}
			set
			{
				if ((this._SERVICE_DATE != value))
				{
					this._SERVICE_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TERMINATION_DATE", DbType="VarChar(8)")]
		public string TERMINATION_DATE
		{
			get
			{
				return this._TERMINATION_DATE;
			}
			set
			{
				if ((this._TERMINATION_DATE != value))
				{
					this._TERMINATION_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STATUS_HIRE", DbType="VarChar(4)")]
		public string STATUS_HIRE
		{
			get
			{
				return this._STATUS_HIRE;
			}
			set
			{
				if ((this._STATUS_HIRE != value))
				{
					this._STATUS_HIRE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STATUS_HIRE_DESC", DbType="VarChar(50)")]
		public string STATUS_HIRE_DESC
		{
			get
			{
				return this._STATUS_HIRE_DESC;
			}
			set
			{
				if ((this._STATUS_HIRE_DESC != value))
				{
					this._STATUS_HIRE_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_POINT_OF_HIRE", DbType="VarChar(4)")]
		public string POINT_OF_HIRE
		{
			get
			{
				return this._POINT_OF_HIRE;
			}
			set
			{
				if ((this._POINT_OF_HIRE != value))
				{
					this._POINT_OF_HIRE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_POINT_OF_HIRE_DESC", DbType="VarChar(50)")]
		public string POINT_OF_HIRE_DESC
		{
			get
			{
				return this._POINT_OF_HIRE_DESC;
			}
			set
			{
				if ((this._POINT_OF_HIRE_DESC != value))
				{
					this._POINT_OF_HIRE_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ACCOUNT_DOMAIN", DbType="VarChar(11)")]
		public string ACCOUNT_DOMAIN
		{
			get
			{
				return this._ACCOUNT_DOMAIN;
			}
			set
			{
				if ((this._ACCOUNT_DOMAIN != value))
				{
					this._ACCOUNT_DOMAIN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NRP", DbType="VarChar(10)")]
		public string NRP
		{
			get
			{
				return this._NRP;
			}
			set
			{
				if ((this._NRP != value))
				{
					this._NRP = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AGE", DbType="Int")]
		public System.Nullable<int> AGE
		{
			get
			{
				return this._AGE;
			}
			set
			{
				if ((this._AGE != value))
				{
					this._AGE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BLOOD_TYPE", DbType="VarChar(2)")]
		public string BLOOD_TYPE
		{
			get
			{
				return this._BLOOD_TYPE;
			}
			set
			{
				if ((this._BLOOD_TYPE != value))
				{
					this._BLOOD_TYPE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RELIGION_DESC", DbType="VarChar(30)")]
		public string RELIGION_DESC
		{
			get
			{
				return this._RELIGION_DESC;
			}
			set
			{
				if ((this._RELIGION_DESC != value))
				{
					this._RELIGION_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RES_ADDRESS_1", DbType="VarChar(32)")]
		public string RES_ADDRESS_1
		{
			get
			{
				return this._RES_ADDRESS_1;
			}
			set
			{
				if ((this._RES_ADDRESS_1 != value))
				{
					this._RES_ADDRESS_1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RES_ADDRESS_2", DbType="VarChar(32)")]
		public string RES_ADDRESS_2
		{
			get
			{
				return this._RES_ADDRESS_2;
			}
			set
			{
				if ((this._RES_ADDRESS_2 != value))
				{
					this._RES_ADDRESS_2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RES_ADDRESS_3", DbType="VarChar(32)")]
		public string RES_ADDRESS_3
		{
			get
			{
				return this._RES_ADDRESS_3;
			}
			set
			{
				if ((this._RES_ADDRESS_3 != value))
				{
					this._RES_ADDRESS_3 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RES_ZIPCODE", DbType="VarChar(10)")]
		public string RES_ZIPCODE
		{
			get
			{
				return this._RES_ZIPCODE;
			}
			set
			{
				if ((this._RES_ZIPCODE != value))
				{
					this._RES_ZIPCODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SUPERIOR_ID", DbType="VarChar(10)")]
		public string SUPERIOR_ID
		{
			get
			{
				return this._SUPERIOR_ID;
			}
			set
			{
				if ((this._SUPERIOR_ID != value))
				{
					this._SUPERIOR_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_POSITION_START_DATE", DbType="VarChar(8)")]
		public string POSITION_START_DATE
		{
			get
			{
				return this._POSITION_START_DATE;
			}
			set
			{
				if ((this._POSITION_START_DATE != value))
				{
					this._POSITION_START_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GOLONGAN", DbType="VarChar(2)")]
		public string GOLONGAN
		{
			get
			{
				return this._GOLONGAN;
			}
			set
			{
				if ((this._GOLONGAN != value))
				{
					this._GOLONGAN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GOL_COMPTCY_LEVEL", DbType="VarChar(2)")]
		public string GOL_COMPTCY_LEVEL
		{
			get
			{
				return this._GOL_COMPTCY_LEVEL;
			}
			set
			{
				if ((this._GOL_COMPTCY_LEVEL != value))
				{
					this._GOL_COMPTCY_LEVEL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GOL_START_DATE", DbType="VarChar(8)")]
		public string GOL_START_DATE
		{
			get
			{
				return this._GOL_START_DATE;
			}
			set
			{
				if ((this._GOL_START_DATE != value))
				{
					this._GOL_START_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HOME_PHONE_NO", DbType="VarChar(16)")]
		public string HOME_PHONE_NO
		{
			get
			{
				return this._HOME_PHONE_NO;
			}
			set
			{
				if ((this._HOME_PHONE_NO != value))
				{
					this._HOME_PHONE_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HOME_MOBILE_NO", DbType="VarChar(16)")]
		public string HOME_MOBILE_NO
		{
			get
			{
				return this._HOME_MOBILE_NO;
			}
			set
			{
				if ((this._HOME_MOBILE_NO != value))
				{
					this._HOME_MOBILE_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RANKS", DbType="VarChar(5)")]
		public string RANKS
		{
			get
			{
				return this._RANKS;
			}
			set
			{
				if ((this._RANKS != value))
				{
					this._RANKS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RANK_DESC", DbType="VarChar(50)")]
		public string RANK_DESC
		{
			get
			{
				return this._RANK_DESC;
			}
			set
			{
				if ((this._RANK_DESC != value))
				{
					this._RANK_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RANK_START_DATE", DbType="VarChar(8)")]
		public string RANK_START_DATE
		{
			get
			{
				return this._RANK_START_DATE;
			}
			set
			{
				if ((this._RANK_START_DATE != value))
				{
					this._RANK_START_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DEPT_CODE", DbType="VarChar(4)")]
		public string DEPT_CODE
		{
			get
			{
				return this._DEPT_CODE;
			}
			set
			{
				if ((this._DEPT_CODE != value))
				{
					this._DEPT_CODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DEPT_DESC", DbType="VarChar(50)")]
		public string DEPT_DESC
		{
			get
			{
				return this._DEPT_DESC;
			}
			set
			{
				if ((this._DEPT_DESC != value))
				{
					this._DEPT_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DEPT_CODE_DESC", DbType="VarChar(50)")]
		public string DEPT_CODE_DESC
		{
			get
			{
				return this._DEPT_CODE_DESC;
			}
			set
			{
				if ((this._DEPT_CODE_DESC != value))
				{
					this._DEPT_CODE_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DIV_CODE", DbType="VarChar(4)")]
		public string DIV_CODE
		{
			get
			{
				return this._DIV_CODE;
			}
			set
			{
				if ((this._DIV_CODE != value))
				{
					this._DIV_CODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DIV_DESC", DbType="VarChar(50)")]
		public string DIV_DESC
		{
			get
			{
				return this._DIV_DESC;
			}
			set
			{
				if ((this._DIV_DESC != value))
				{
					this._DIV_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DIV_CODE_DESC", DbType="VarChar(50)")]
		public string DIV_CODE_DESC
		{
			get
			{
				return this._DIV_CODE_DESC;
			}
			set
			{
				if ((this._DIV_CODE_DESC != value))
				{
					this._DIV_CODE_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address_LotusNotes", DbType="NVarChar(255)")]
		public string Address_LotusNotes
		{
			get
			{
				return this._Address_LotusNotes;
			}
			set
			{
				if ((this._Address_LotusNotes != value))
				{
					this._Address_LotusNotes = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email_Internet", DbType="NVarChar(255)")]
		public string Email_Internet
		{
			get
			{
				return this._Email_Internet;
			}
			set
			{
				if ((this._Email_Internet != value))
				{
					this._Email_Internet = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ACTIVE_STATUS", DbType="Int")]
		public System.Nullable<int> ACTIVE_STATUS
		{
			get
			{
				return this._ACTIVE_STATUS;
			}
			set
			{
				if ((this._ACTIVE_STATUS != value))
				{
					this._ACTIVE_STATUS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GENDER", DbType="VarChar(1)")]
		public string GENDER
		{
			get
			{
				return this._GENDER;
			}
			set
			{
				if ((this._GENDER != value))
				{
					this._GENDER = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NAME_INITCAP", DbType="VarChar(43)")]
		public string NAME_INITCAP
		{
			get
			{
				return this._NAME_INITCAP;
			}
			set
			{
				if ((this._NAME_INITCAP != value))
				{
					this._NAME_INITCAP = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RELIGION", DbType="VarChar(30)")]
		public string RELIGION
		{
			get
			{
				return this._RELIGION;
			}
			set
			{
				if ((this._RELIGION != value))
				{
					this._RELIGION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MODIFIED_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> MODIFIED_DATE
		{
			get
			{
				return this._MODIFIED_DATE;
			}
			set
			{
				if ((this._MODIFIED_DATE != value))
				{
					this._MODIFIED_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RANKS_DESC", DbType="VarChar(50)")]
		public string RANKS_DESC
		{
			get
			{
				return this._RANKS_DESC;
			}
			set
			{
				if ((this._RANKS_DESC != value))
				{
					this._RANKS_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RANKS_START_DATE", DbType="VarChar(8)")]
		public string RANKS_START_DATE
		{
			get
			{
				return this._RANKS_START_DATE;
			}
			set
			{
				if ((this._RANKS_START_DATE != value))
				{
					this._RANKS_START_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SECONDARY_POSITION_ID", DbType="VarChar(10)")]
		public string SECONDARY_POSITION_ID
		{
			get
			{
				return this._SECONDARY_POSITION_ID;
			}
			set
			{
				if ((this._SECONDARY_POSITION_ID != value))
				{
					this._SECONDARY_POSITION_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LAST_EDUCATION", DbType="VarChar(5)")]
		public string LAST_EDUCATION
		{
			get
			{
				return this._LAST_EDUCATION;
			}
			set
			{
				if ((this._LAST_EDUCATION != value))
				{
					this._LAST_EDUCATION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BIRTH_PLACE", DbType="VarChar(4)")]
		public string BIRTH_PLACE
		{
			get
			{
				return this._BIRTH_PLACE;
			}
			set
			{
				if ((this._BIRTH_PLACE != value))
				{
					this._BIRTH_PLACE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BIRTH_PLACE_DESC", DbType="VarChar(50)")]
		public string BIRTH_PLACE_DESC
		{
			get
			{
				return this._BIRTH_PLACE_DESC;
			}
			set
			{
				if ((this._BIRTH_PLACE_DESC != value))
				{
					this._BIRTH_PLACE_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GROUP_GOLONGAN", DbType="VarChar(1)")]
		public string GROUP_GOLONGAN
		{
			get
			{
				return this._GROUP_GOLONGAN;
			}
			set
			{
				if ((this._GROUP_GOLONGAN != value))
				{
					this._GROUP_GOLONGAN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MARITAL_STATUS", DbType="VarChar(1)")]
		public string MARITAL_STATUS
		{
			get
			{
				return this._MARITAL_STATUS;
			}
			set
			{
				if ((this._MARITAL_STATUS != value))
				{
					this._MARITAL_STATUS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MARITAL_STATUS_DESC", DbType="VarChar(50)")]
		public string MARITAL_STATUS_DESC
		{
			get
			{
				return this._MARITAL_STATUS_DESC;
			}
			set
			{
				if ((this._MARITAL_STATUS_DESC != value))
				{
					this._MARITAL_STATUS_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HCGS_CONV", DbType="VarChar(10)")]
		public string HCGS_CONV
		{
			get
			{
				return this._HCGS_CONV;
			}
			set
			{
				if ((this._HCGS_CONV != value))
				{
					this._HCGS_CONV = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KELAS_KAMAR", DbType="VarChar(8)")]
		public string KELAS_KAMAR
		{
			get
			{
				return this._KELAS_KAMAR;
			}
			set
			{
				if ((this._KELAS_KAMAR != value))
				{
					this._KELAS_KAMAR = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TARIF", DbType="Float")]
		public System.Nullable<double> TARIF
		{
			get
			{
				return this._TARIF;
			}
			set
			{
				if ((this._TARIF != value))
				{
					this._TARIF = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KELAS_PESAWAT", DbType="VarChar(10)")]
		public string KELAS_PESAWAT
		{
			get
			{
				return this._KELAS_PESAWAT;
			}
			set
			{
				if ((this._KELAS_PESAWAT != value))
				{
					this._KELAS_PESAWAT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MARITAL_CODE", DbType="VarChar(2)")]
		public string MARITAL_CODE
		{
			get
			{
				return this._MARITAL_CODE;
			}
			set
			{
				if ((this._MARITAL_CODE != value))
				{
					this._MARITAL_CODE = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
