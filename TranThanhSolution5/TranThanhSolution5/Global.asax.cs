using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TranThanhSolution5.Models.Data;
using TranThanhSolution5.Models.View;

namespace TranThanhSolution5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Model Mapper config
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CreateStudentView, Student>();
                cfg.CreateMap<EditStudentView, Student>()
                .ForMember(destinationMember => destinationMember.Uuid, opt => opt.Ignore() )
                .ForSourceMember(sourceMember=>sourceMember.UpdateAt, opt => opt.Ignore()) ;

                cfg.CreateMap<Student, StudentListItemView>();
            });
        }
    }
}
