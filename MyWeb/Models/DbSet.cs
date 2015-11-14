//--
//创建实体模型
//--
namespace MyWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Data.Entity.Infrastructure;

    public class MyEntity
    {
        [Key]
        public Int64 Id { get; set; }
        //**
        [Display(Name = "模块名称")]
        [Required(ErrorMessage = "模块名称不能为空")]
        public string Name { get; set; }
        //**
        [DisplayName("正文")]
        [Required(ErrorMessage = "正文必须填写")]
        public string CheJian { get; set; }
        //**
        [Display(Name = "链接地址")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "链接地址{2}～{1}个字符")]
        public string LinkUrl { get; set; }
        //**
        [Display(Name = "排序")]
        [Required(ErrorMessage = "排序不能为空")]
        [RegularExpression(@"\d+", ErrorMessage = "排序必须是数字")]
        public int OrderSort { get; set; }
        //**
        [Display(Name = "注册时间")]
        public DateTime? RegisterTime { get; set; }
        //**
        [Display(Name = "最后登陆时间")]
        public DateTime? LastLoginTime { get; set; }
        //**
        [Display(Name = "是否菜单")]
        public bool IsMenu { get; set; }
        public string MenuText
        {
            get
            {
                if (IsMenu == true)
                {
                    return "是";
                }
                else
                {
                    return "否";
                }
            }
            set { }
        }
    }
    //文章实体模型
    public class WenZhang
    {
        [Key]
        public int ID { get; set; }
        /**------------------------------------**/
        [Display(Name = "文章标题")]
        [Required(ErrorMessage = "文章标题不能为空")]
        public string BiaoTi { get; set; }
        /**------------------------------------**/
        [Display(Name = "文章简要")]
        [Required(ErrorMessage = "文章简要不能为空")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "文章简要请在{2}～{1}个字符之间")]
        public string JianYao { get; set; }
        /**------------------------------------**/
        [Display(Name = "正文内容")]
        [Required(ErrorMessage = "正文内容不能为空")]
        public string ZhengWenNeiRong { get; set; }
        /**------------------------------------**/
        [Display(Name = "简要图片")]
        [Required(ErrorMessage = "简要图片不能为空，请上传图片。")]
        public string JianYaoTuPian { get; set; }
        /**------------------------------------**/
        [Display(Name = "作者")]
        public Nullable<int> YongHuID { get; set; }
        /**------------------------------------**/
        [Display(Name = "发表时间")]
        public System.DateTime ChuangJianRiQi { get; set; }
        /**------------------------------------**/
        [Display(Name = "最后修改时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime XiuGaiRiQi { get; set; }
        /**------------------------------------**/
        [Display(Name = "评论")]
        public Nullable<int> PingLunLiang { get; set; }
        /**------------------------------------**/
        [Display(Name = "收藏")]
        public Nullable<int> ShouCangLiang { get; set; }
        /**------------------------------------**/
        [Display(Name = "阅读")]
        public Nullable<int> YueDuLiang { get; set; }
        /**------------------------------------**/

        public virtual YongHu YongHu { get; set; }
    }
    //用户实体模型
    public  class YongHu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public YongHu()
        {
            this.WenZhang = new HashSet<WenZhang>();
            this.YongHuMing = "李斌";
        }

        public int ID { get; set; }
        /**------------------------------------**/
        [Display(Name = "用户名")]
        public string YongHuMing { get; set; }
        /**------------------------------------**/
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WenZhang> WenZhang { get; set; }
    }
}