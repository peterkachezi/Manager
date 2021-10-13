using System;

using Unity;
using Manager.Data.DepartmentModule;
using Manager.Data.DesignationModule;
using Manager.Data.Services.AdmissionNumberModule;
using Manager.Data.Services.AttendancesModule;
using Manager.Data.Services.AuthorModule;
using Manager.Data.Services.BookModule;
using Manager.Data.Services.ClassModule;
using Manager.Data.Services.CountyModule;
using Manager.Data.Services.EmployeeModule;
using Manager.Data.Services.ExaminationModule;
using Manager.Data.Services.ExpenseTypeModule;
using Manager.Data.Services.ExpensModule;
using Manager.Data.Services.GradingSystemHumanityModule;
using Manager.Data.Services.GradingSystemLanguagesModule;
using Manager.Data.Services.GradingSystemMathematicsModule;
using Manager.Data.Services.GradingSystemModule;
using Manager.Data.Services.GradingSystemSciencesModule;
using Manager.Data.Services.GradingSystemTechnicalsModule;
using Manager.Data.Services.HostelModule;
using Manager.Data.Services.HumanityModule;
using Manager.Data.Services.InstituitonModule;
using Manager.Data.Services.ParentModule;
using Manager.Data.Services.PublisherModule;
using Manager.Data.Services.ResultsModule;
using Manager.Data.Services.SubjectCategoryModule;
using Manager.Data.Services.SubjectModule;
using Manager.Data.Services.SupplierModule;
using Manager.Data.Services.VisitorModule;
using Manager.Data.StudentModule;
using Manager.Manager.Data.DepartmentModule;
using Microsoft.AspNet.Identity.EntityFramework;
using Manager.Models;
using Manager.Controllers;
using Unity.Injection;
using Manager.Data.StreamModule;

namespace Manager
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();


            container.RegisterType<AccountController>(new InjectionConstructor());

            container.RegisterType<Microsoft.AspNet.Identity.IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();

            container.RegisterType(typeof(Microsoft.AspNet.Identity.IUserStore<>), typeof(UserStore<>));


            container.RegisterType<IStreamService, StreamService>();

            container.RegisterType<IDesignationService, DesignationService>();

            container.RegisterType<IDepartmentService, DepartmentService>();

            container.RegisterType<IEmployeeService, EmployeeService>();

            container.RegisterType<IHostelService, HostelService>();

            container.RegisterType<ICountyService, CountyService>();

            container.RegisterType<ISubjectService, SubjectService>();

            container.RegisterType<IHumanityGradingService, HumanityGradingService>();

            container.RegisterType<ISubjectCategoryService, SubjectCategoryService>();

            container.RegisterType<IAttendanceService, AttendanceService>();

            container.RegisterType<IClassService, ClassService>();

            container.RegisterType<IStudentService, StudentService>();

            container.RegisterType<IExaminationService, ExaminationService>();

            container.RegisterType<IPublisherService, PublisherService>();

            container.RegisterType<IAuthorService, AuthorService>();

            container.RegisterType<ISupplierService, SupplierService>();

            container.RegisterType<IBookService, BookService>();

            container.RegisterType<IParentService, ParentService>();

            container.RegisterType<IVisitorService, VisitorService>();

            container.RegisterType<IExpensService, ExpensService>();

            container.RegisterType<IExpenseTypeService, ExpenseTypeService>();

            container.RegisterType<IAdmissionNumberService, AdmissionNumberService>();

            container.RegisterType<IInstituitonService, InstituitonService>();

            container.RegisterType<ILanguagesService, LanguagesService>();

            container.RegisterType<ISciencesService, SciencesService>();

            container.RegisterType<IHumanityService, HumanityService>();

            container.RegisterType<IMathsService, MathsService>();

            container.RegisterType<ITechnicalService, TechnicalService>();

            container.RegisterType<IExamResultService, ExamResultService>();
        }
    }
}