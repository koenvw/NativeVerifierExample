using Sdl.Core.Settings;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.FileTypeSupport.Framework.NativeApi;
using System;


namespace NativeVerifierExample
{
    /// <summary>
    /// This class implements the verification logic. Depending on whether the 
    /// verification plug-in is enabled or not, a verification will be performed
    /// when the user of SDL Trados Studio presses F8 or invokes the menu command
    /// Tools -> Verify.
    /// This class is referenced in the file type definition.
    /// </summary>
    class XMLCheckerMain : INativeFileVerifier, ISettingsAware
    {
        #region "_outputFileProperties"
        private INativeOutputFileProperties _outputFileProperties;
        #endregion

        #region "UISettingsRepresentation"
        public bool Enabled
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// Initializes the plug-in settings, so that they can be used during the actual verification.
        /// </summary>
        /// <param name="settingsBundle"></param>
        /// <param name="configurationId"></param>
        #region "InitializeSettings"
        public void InitializeSettings(ISettingsBundle settingsBundle, string configurationId)
        {
            Enabled = true;
        }
        #endregion



        #region "message reporter"
        public INativeTextLocationMessageReporter MessageReporter
        {
            get;
            set;
        }
        #endregion


        /// <summary>
        /// This method implements the main verification logic.
        /// First, the XML document is loaded into a DOM object.
        /// Then, the method loops through all the 'displaytext' elements, and
        /// checks for the presence of a 'maxlength' attribute, which indicates
        /// the maximum length in characters. If the target segment text exceeds the
        /// length limit specified by the attribute, an error message will be reported.
        /// Any length limit violations will be reported through the message reporter,
        /// which will fill the Messages window of SDL Trados Studio with the error
        /// messages that will be displayed to the end user.
        /// </summary>
        #region "verification logic"
        public void Verify()
        {
            if (!Enabled)
            {
                return;
            }

            // report problem
            MessageReporter.ReportMessage(this, StringResources.VerifierName, ErrorLevel.Error,
                String.Format(StringResources.ErrorText, "", ""),
                String.Format(StringResources.LocationDescription, ""));
        }
        #endregion



        #region "INativeOutputSettingsAware Members"
        public void GetProposedOutputFileInfo(IPersistentFileConversionProperties fileProperties, IOutputFileInfo proposedFileInfo)
        {
            // Not required for this implementation
        }


        /// <summary>
        /// Provides information on output file.
        /// </summary>
        /// <param name="properties"></param>
        public void SetOutputProperties(INativeOutputFileProperties properties)
        {
            _outputFileProperties = properties;
        }
        #endregion
    }
}
