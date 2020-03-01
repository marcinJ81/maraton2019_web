[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(maratonMszana_v4.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(maratonMszana_v4.App_Start.NinjectWebCommon), "Stop")]

namespace maratonMszana_v4.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using LibDatabase.Repositories;
    using LibDatabase.Repositories.Filters;
    using LibDatabase.verification;
    using SendMail;
    using ThrowException.Exceptions;
    using Filters;
    using VerificationData;
    using SendMail.DescriptionVerificationNumber;
    using SendMail.DescriptionEndMail;
    using OneFilter;
    using LibDatabase.TestingData;
    using SendMail.SendEmailVerification;
    using SendMail.SendConfirmRegistration;
    using LibDatabase.zawodnik;
    using SendMail.UniversalMessage;
    using Reports;
    using Abstract_And_Model_Layer;
    using ModelParticipants;
    using MarthonOffice;
    using Abstract_And_Model_Layer.Marthon_Office_Model;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IregistrationList>().To<RegistrationExtModel>();
            kernel.Bind<IDystans>().To<DystansFiltr>();
            kernel.Bind<IGrupa>().To<GrupaFiltr>();
            kernel.Bind<IPlec>().To<PlecFiltr>();
            kernel.Bind<ICheckWerification>().To<CheckWerification>();
            kernel.Bind<ISMTP_Configuration>().To<SMTP_Configuration>();
            kernel.Bind<IExceptionBase>().To<ExceptionToBase>();
            kernel.Bind<IUniqueException>().To<UniqueException2>();
            kernel.Bind<IRandomNumber>().To<RandomNumbers>();
            kernel.Bind<INewRecord>().To<NewRecord>();
            kernel.Bind<ICreatingFilters>().To<CreatingFilters>();
            kernel.Bind<IDescriptionVerificationNumber>().To<DescriptionVerificationNumber>();
            kernel.Bind<IDataForDescription>().To<DescriptionEndMailGetData>(); //it`s ok
            kernel.Bind<IDescriptionEndCreate>().To<DescriptionEndCreate>();
            kernel.Bind<IFiltersOperations>().To<FiltersOperations>();
            kernel.Bind<IFilterBool>().To<FilterBool>();
            kernel.Bind<ICheckValue>().To<CheckValue>();
            kernel.Bind<IOneFilter>().To<OneFilter>();
            kernel.Bind<ICreateDataToTestKartoteka>().To<CreateDataToTestKartoteka>();
            kernel.Bind<ISendingVerifyingEmail>().To<SendingVerifyingEmail>();
            kernel.Bind<ISendingConfirmationRegistrationEmail>().To<SendingConfirmationRegistrationEmail>();
            kernel.Bind<ISendingEmailTimeVerification>().To<SendingEmailTimeVerification>();
            kernel.Bind<IAddZawodnik>().To<AddZawodnik>();
            kernel.Bind<IPlayerVerfication>().To<PlayerVerification>();
            kernel.Bind<IEmailDescritpion>().To<CreatingEmailDescription>();
            kernel.Bind<ICreatingMailMessage>().To<CreatingMailMessage>();
            kernel.Bind<IZawodnikInfo>().To<ZawodnikInfo>(); //test danych do raportu
            kernel.Bind<IParticipantResultList>().To<ParticipantResultList>();
            kernel.Bind<IParticipantStartingGroup>().To<ParticipantStartingGroup>();
            kernel.Bind<IInfoAboutParticipant>().To<InfoAboutParticipant>();
            kernel.Bind<IOfficeEntities>().To<OfficeEntities>();
            kernel.Bind<IStoredProcedures>().To<StoredProceduresOfficeMarathon>();
            
        }        
    }
}
