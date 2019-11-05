using Sdl.FileTypeSupport.Framework.IntegrationApi;
using System.Collections.Generic;

namespace NativeVerifierExample
{
    public class VerifierFilterComponentBuilder : IFileTypeComponentBuilderAdapter
    {
        #region BuildFileTypeInformation
        public virtual IFileTypeInformation BuildFileTypeInformation(string name)
        {
            var fileTypeInformation = Original.BuildFileTypeInformation(name);

            return fileTypeInformation;
        }
        #endregion

        #region BuildVerifierCollection
        public virtual IVerifierCollection BuildVerifierCollection(string name)
        {
            IVerifierCollection verifierCollection = Original.BuildVerifierCollection(name);
            verifierCollection.NativeVerifiers.Add(new XMLCheckerMain());
            return verifierCollection;
        }
        #endregion

        public virtual IFileTypeComponentBuilder Original { get; set; }

        public virtual IAbstractGenerator BuildAbstractGenerator(string name)
        {
            return Original.BuildAbstractGenerator(name);
        }

        public virtual IAdditionalGeneratorsInfo BuildAdditionalGeneratorsInfo(string name)
        {
            return Original.BuildAdditionalGeneratorsInfo(name);
        }

        public virtual IBilingualDocumentGenerator BuildBilingualGenerator(string name)
        {
            return Original.BuildBilingualGenerator(name);
        }

        public virtual IFileExtractor BuildFileExtractor(string name)
        {
            return Original.BuildFileExtractor(name);
        }

        public virtual IFileGenerator BuildFileGenerator(string name)
        {
            return Original.BuildFileGenerator(name);
        }

        public virtual Sdl.FileTypeSupport.Framework.NativeApi.INativeFileSniffer BuildFileSniffer(string name)
        {
            return Original.BuildFileSniffer(name);
        }

        public virtual IAbstractPreviewApplication BuildPreviewApplication(string name)
        {
            return Original.BuildPreviewApplication(name);
        }

        public virtual IAbstractPreviewControl BuildPreviewControl(string name)
        {
            return Original.BuildPreviewControl(name);
        }

        public virtual IPreviewSetsFactory BuildPreviewSetsFactory(string name)
        {
            return Original.BuildPreviewSetsFactory(name);
        }

        public virtual IQuickTagsFactory BuildQuickTagsFactory(string name)
        {
            return Original.BuildQuickTagsFactory(name);
        }

        public virtual IFileTypeManager FileTypeManager { get; set; }

        public virtual IFileTypeDefinition FileTypeDefinition { get; set; }
    }
}