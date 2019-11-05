using Sdl.FileTypeSupport.Framework.IntegrationApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeVerifierExample
{
    [FileTypeComponentBuilderExtension(
         Id = "BMW_Xml2p_Id",
         Name = "BMW_Xml2p_Name",
         Description = "BMW_Xml2_Descript",
         OriginalFileType = "XML v 1.2.0.0")]
    class XMLFileTypeBuilder: VerifierFilterComponentBuilder
    {
    }
}
