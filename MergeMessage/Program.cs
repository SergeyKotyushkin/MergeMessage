using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using log4net;

using MergeMessage.Business.Initialization;
using MergeMessage.Common.Contracts.Services;
using MergeMessage.Common.Enums;
using MergeMessage.Common.Models;

using StructureMap;

namespace MergeMessage
{
    static class Program
    {
        private const string SettingsFileName = "settings.ini";

        private static IContainer _container;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Info("Application has been started");
            _container = CreateStructureMapContainer();
            var initializationResult = InitializeSettings();

            if (!initializationResult)
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(_container.GetInstance<MainForm>());
            Logger.Info("Application has been finished");
        }

        private static bool InitializeSettings()
        {
            var settingsService = _container.GetInstance<ISettingsService>();
            var alertService = _container.GetInstance<IAlertService>();

            var directoryName = Path.GetDirectoryName(Application.ExecutablePath);
            if (directoryName == null)
            {
                const string errorMessage = "An executable directory has not been found";
                alertService.Alert(new AlertEntity("Error", errorMessage, AlertType.Error));
                Logger.Error(errorMessage);
                return false;
            }

            var settingsFilePath = Path.Combine(directoryName, SettingsFileName);

            IList<string> errorMessages;
            var branches = settingsService.TryParse(settingsFilePath, out errorMessages);

            if (errorMessages.Count > 0)
            {
                var errorMessage =
                    $"Some errors have been occured on settings file parsing: {string.Join(", ", errorMessages)}";
                alertService.Alert(new AlertEntity("Error", errorMessage, AlertType.Error));
                Logger.Error(errorMessage);
                return false;
            }

            var branchRepository = _container.GetInstance<IBranchRepository>();
            foreach (var branch in branches)
            {
                branchRepository.Save(branch);
            }

            return true;
        }

        private static Container CreateStructureMapContainer()
        {
            var container = new Container(builder => { builder.AddRegistry<BusinessRegestry>(); });

            return container;
        }
    }
}
