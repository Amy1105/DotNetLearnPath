using AutoMapper;
using AutoMapperDemo.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperDemo.Profiles
{
    internal class MyEntityProfile:Profile
    {
        public MyEntityProfile()
        {
            //命名约定 ： property_name -> PropertyName
            SourceMemberNamingConvention = LowerUnderscoreNamingConvention.Instance;
            DestinationMemberNamingConvention = PascalCaseNamingConvention.Instance;
            CreateMap<User, UserDto>();

            //替换字符
            CreateMap<SourceModel, DestinationModel>().ForMember(
                dest => dest.FormattedText,  // 目标属性
                opt => opt.MapFrom(src =>
                    src.RawText.Replace("_", "-")  // 替换下划线为连字符
                )
            );

            // 创建自定义命名约定
            var customNamingConvention = new CustomNamingConvention(
                new PascalCaseNamingConvention(),
                "fld_"
            );

            // 应用到当前 Profile 的目标属性命名
            Configuration.DestinationMemberNamingConvention = customNamingConvention;


            CreateMap<SourceCls, DestinationCls>();           

            //全局属性/字段过滤


        }
    }
}
