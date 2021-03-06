#pragma checksum "C:\Users\Dnarvaez\source\repos\Book\WEBBook\Views\Estudiante\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf76741a26b6c4445d655214f213bc949b68f384"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Estudiante_Index), @"mvc.1.0.view", @"/Views/Estudiante/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Dnarvaez\source\repos\Book\WEBBook\Views\_ViewImports.cshtml"
using WEBBook;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dnarvaez\source\repos\Book\WEBBook\Views\_ViewImports.cshtml"
using WEBBook.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Dnarvaez\source\repos\Book\WEBBook\Views\_ViewImports.cshtml"
using WEBBook.Resource;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf76741a26b6c4445d655214f213bc949b68f384", @"/Views/Estudiante/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac2dfc18cb31b7b541421962a04858f6ce0bc5d1", @"/Views/_ViewImports.cshtml")]
    public class Views_Estudiante_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/crudEstudiantes.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""card"" style=""margin-top:30px"">
    <div class=""card-header bg-dark text-light ml-0 row container"">
        <div class=""col-md-6"">
            <i class=""fa fa-user-circle""></i>&nbsp; Estudiante
        </div>
        <div class=""col-md-6 text-right"">
            <button class=""btn btn-sm btn-primary fa fa-plus"" onclick=""showModal()"" style=""float:right"" title=""Agregar""></button>
        </div>
    </div>
    <div class=""card-body"">
        <table id=""estudianteData"" class=""table table-bordered"">
            <thead>
                <tr>
                    <th>CI</th>
                    <th>Nombre</th>
                    <th>Direccion</th>
                    <th>Carrera</th>
                    <th>Edad</th>
                    <th>Opciones</th>
                </tr>
            </thead>
        </table>
    </div>
</div>

<!-- Modal -->
<div class=""modal fade"" id=""mdEstudiante"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
   ");
            WriteLiteral(@" <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLongTitle""></h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""form-group"" style=""display:none"">
                    <label for=""idLector"">Id</label>
                    <input type=""text"" class=""form-control"" id=""idLector"">
                    <input type=""text"" class=""form-control"" value=""false"" id=""isNew"">
                </div>
                <div class=""form-group"">
                    <label for=""ciEstudiante"">CI</label>
                    <input type=""text"" class=""form-control"" id=""ciEstudiante"" placeholder=""CI"">
                </div>
                <div class=""form-group"">");
            WriteLiteral(@"
                    <label for=""nombreEstudiante"">Nombre</label>
                    <input type=""text"" class=""form-control"" id=""nombreEstudiante"" placeholder=""Nombre"">
                </div>
                <div class=""form-group"">
                    <label for=""direccionEstudiante"">Direccion</label>
                    <input type=""text"" class=""form-control"" id=""direccionEstudiante"" placeholder=""Dirección"">
                </div>
                <div class=""form-group"">
                    <label for=""carreraEstudiante"">Carrera</label>
                    <input type=""text"" class=""form-control"" id=""carreraEstudiante"" placeholder=""Carrera"">
                </div>
                <div class=""form-group"">
                    <label for=""edadEstudiante"">Edad</label>
                    <input type=""number"" class=""form-control"" id=""edadEstudiante"" placeholder=""Edad"">
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""bt");
            WriteLiteral("n btn-primary\" id=\"btnSave\" onclick=\"SaveOrUpdate()\">Guardar</button>\r\n                <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Close</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf76741a26b6c4445d655214f213bc949b68f3847281", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n ");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
