using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutoMapperDemo.Profiles
{
    public class UserDto
    {

        /// <summary>
        ///帐号
        /// </summary>
        [Display(Name = "帐号")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        /// <summary>
        ///OA账号
        /// </summary>
        [Display(Name = "OA账号")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string OaAccount { get; set; }

        /// <summary>
        ///厂区位置
        /// </summary>
        [Display(Name = "厂区位置")]
        [MaxLength(400)]
        [Column(TypeName = "nvarchar(400)")]
        [Editable(true)]
        public string Positions { get; set; }

        /// <summary>
        ///性别
        /// </summary>
        [Display(Name = "性别")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? Gender { get; set; }

        /// <summary>
        ///头像
        /// </summary>
        [Display(Name = "头像")]
        [MaxLength(400)]
        [Column(TypeName = "nvarchar(400)")]
        [Editable(true)]
        public string HeadImageUrl { get; set; }

        /// <summary>
        ///部门
        /// </summary>
        [Display(Name = "部门")]
        [MaxLength(300)]
        [Column(TypeName = "nvarchar(300)")]
        [Editable(true)]
        public string DeptName { get; set; }

        /// <summary>
        ///角色
        /// </summary>
        [Display(Name = "角色")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int Role_Id { get; set; }

        /// <summary>
        ///真实姓名
        /// </summary>
        [Display(Name = "真实姓名")]
        [MaxLength(40)]
        [Column(TypeName = "nvarchar(40)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string UserTrueName { get; set; }

        /// <summary>
        ///是否可用
        /// </summary>
        [Display(Name = "是否可用")]
        [Column(TypeName = "tinyint")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public byte Enable { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Key]
        [Display(Name = "User_Id")]
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        public int User_Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Dept_Id")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? Dept_Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "RoleName")]
        [MaxLength(300)]
        [Column(TypeName = "nvarchar(300)")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public string RoleName { get; set; }

        /// <summary>
        ///Token
        /// </summary>
        [Display(Name = "Token")]
        [MaxLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        [Editable(true)]
        public string Token { get; set; }

        /// <summary>
        ///登陆设备类型
        /// </summary>
        [Display(Name = "登陆设备类型")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? AppType { get; set; }

        /// <summary>
        ///密码
        /// </summary>
        [Display(Name = "密码")]
        [MaxLength(400)]
        [JsonIgnore]
        [Column(TypeName = "nvarchar(400)")]
        [Editable(true)]
        public string UserPwd { get; set; }

        /// <summary>
        ///手机用户
        /// </summary>
        [Display(Name = "手机用户")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int IsRegregisterPhone { get; set; }

        /// <summary>
        ///手机号
        /// </summary>
        [Display(Name = "手机号")]
        [MaxLength(22)]
        [Column(TypeName = "nvarchar(22)")]
        [Editable(true)]
        public string PhoneNo { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Tel")]
        [MaxLength(40)]
        [Column(TypeName = "nvarchar(40)")]
        [Editable(true)]
        public string Tel { get; set; }

        /// <summary>
        ///审核状态
        /// </summary>
        [Display(Name = "审核状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? AuditStatus { get; set; }

        /// <summary>
        ///审核人
        /// </summary>
        [Display(Name = "审核人")]
        [MaxLength(400)]
        [Column(TypeName = "nvarchar(400)")]
        [Editable(true)]
        public string Auditor { get; set; }

        /// <summary>
        ///审核时间
        /// </summary>
        [Display(Name = "审核时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? AuditDate { get; set; }

        /// <summary>
        ///最后登陆时间
        /// </summary>
        [Display(Name = "最后登陆时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        ///最后密码修改时间
        /// </summary>
        [Display(Name = "最后密码修改时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? LastModifyPwdDate { get; set; }

        /// <summary>
        ///地址
        /// </summary>
        [Display(Name = "地址")]
        [MaxLength(400)]
        [Column(TypeName = "nvarchar(400)")]
        [Editable(true)]
        public string Address { get; set; }

        /// <summary>
        ///电话
        /// </summary>
        [Display(Name = "电话")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string Mobile { get; set; }

        /// <summary>
        ///Email
        /// </summary>
        [Display(Name = "Email")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Editable(true)]
        public string Email { get; set; }

        /// <summary>
        ///备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(400)]
        [Column(TypeName = "nvarchar(400)")]
        [Editable(true)]
        public string Remark { get; set; }

        /// <summary>
        ///排序号
        /// </summary>
        [Display(Name = "排序号")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? OrderNo { get; set; }

        /// <summary>
        ///班组
        /// </summary>
        [Display(Name = "班组")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string TeamGroupId { get; set; }

        /// <summary>
        ///工号
        /// </summary>
        [Display(Name = "工号")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Editable(true)]
        public string JobNo { get; set; }



        [Display(Name = "员工状态")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string FdEmployeesState { get; set; }



        [Display(Name = "组织编码")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string FdOrganizationalNo { get; set; }


        [Display(Name = "组织名称")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string FdOrganizationalName { get; set; }



        [Display(Name = "总监姓名")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string FdDirectSupervisorName { get; set; }


        [Display(Name = "总监工号")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string FdDirectSupervisorNo { get; set; }


        [Display(Name = "直接主管姓名")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string FdDepartmentHeadName { get; set; }


        [Display(Name = "直接主管工号")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string FdDepartmentHeadNo { get; set; }
    }
}