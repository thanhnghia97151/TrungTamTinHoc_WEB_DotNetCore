#pragma checksum "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e490fa03832c75c31cd5fc1050e516373b3ea3b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Menu_Multiple), @"mvc.1.0.view", @"/Views/Menu/Multiple.cshtml")]
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
#line 1 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\_ViewImports.cshtml"
using WebApp1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\_ViewImports.cshtml"
using WebApp1.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e490fa03832c75c31cd5fc1050e516373b3ea3b", @"/Views/Menu/Multiple.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb8f415ee837e403ed49c567f4539b4c654de94d", @"/Views/_ViewImports.cshtml")]
    public class Views_Menu_Multiple : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Category>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/navbar_multi.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5e490fa03832c75c31cd5fc1050e516373b3ea3b3818", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<nav class=""navbar navbar-expand-lg navbar-dark bg-primary"">
	<div class=""container-fluid"">
		<a class=""navbar-brand"" href=""#"">Brand</a>
		<button class=""navbar-toggler"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#main_nav""  aria-expanded=""false"" aria-label=""Toggle navigation"">
			<span class=""navbar-toggler-icon""></span>
		</button>
		<div class=""collapse navbar-collapse"" id=""main_nav"">
		  	<ul class=""navbar-nav"">
");
            WriteLiteral("\r\n\t\t\t\t\r\n\t\t\t\r\n");
#nullable restore
#line 39 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
                             foreach (var item in Model)
							{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<li class=\"nav-item dropdown\">\r\n\t\t\t\t\t\t\t\t<a class=\"nav-link dropdown-toggle\" data-bs-toggle=\"dropdown\" href=\"#\">");
#nullable restore
#line 42 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
                                                                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 43 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
                                 if (item.Children != null)
								{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<ul class=\"dropdown-menu\">\r\n");
#nullable restore
#line 46 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
                                         foreach (var child in item.Children)
										{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t<li>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 2386, "\"", 2404, 2);
            WriteAttributeValue("", 2393, "#/", 2393, 2, true);
#nullable restore
#line 49 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
WriteAttributeValue("", 2395, child.Id, 2395, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 49 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
                                                                                       Write(child.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 50 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
                                                 if (child.Children != null)
												{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t<ul  class=\"submenu dropdown-menu\">\r\n");
#nullable restore
#line 53 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
                                                         foreach (var child2 in child.Children)
														{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<li>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 2663, "\"", 2682, 2);
            WriteAttributeValue("", 2670, "#/", 2670, 2, true);
#nullable restore
#line 56 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
WriteAttributeValue("", 2672, child2.Id, 2672, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 56 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
                                                                                                        Write(child2.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 57 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
                                                                     if (child2.Children != null)
																	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<ul  class=\"submenu dropdown-menu\">\r\n");
#nullable restore
#line 60 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
                                                                             foreach (var child3 in child2.Children)
																			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<li><a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 2956, "\"", 2975, 2);
            WriteAttributeValue("", 2963, "#/", 2963, 2, true);
#nullable restore
#line 62 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
WriteAttributeValue("", 2965, child3.Id, 2965, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 62 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
                                                                                                                            Write(child3.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 63 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
																			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</ul>\r\n");
#nullable restore
#line 65 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
																	}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</li>\r\n");
#nullable restore
#line 67 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
														}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t</ul>\r\n");
#nullable restore
#line 69 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
												}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t</li>\r\n");
#nullable restore
#line 71 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
										}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t</ul>\r\n");
#nullable restore
#line 73 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
								}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t</li>\r\n");
#nullable restore
#line 75 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Views\Menu\Multiple.cshtml"
							}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


		  	</ul>
		</div>
	</div>
</nav>
<script>
	document.addEventListener(""DOMContentLoaded"", function(){
	// make it as accordion for smaller screens
	if (window.innerWidth < 992) {
	  // close all inner dropdowns when parent is closed
	  document.querySelectorAll('.navbar .dropdown').forEach(function(everydropdown){
	    everydropdown.addEventListener('hidden.bs.dropdown', function () {
	      // after dropdown is hidden, then find all submenus
	        this.querySelectorAll('.submenu').forEach(function(everysubmenu){
	          // hide every submenu as well
	          everysubmenu.style.display = 'none';
	        });
	    })
	  });
	  document.querySelectorAll('.dropdown-menu a').forEach(function(element){
	    element.addEventListener('click', function (e) {
	        let nextEl = this.nextElementSibling;
	        if(nextEl && nextEl.classList.contains('submenu')) {	
	          // prevent opening link if link needs to open dropdown
	          e.preventDefault();
	          if(nex");
            WriteLiteral("tEl.style.display == \'block\'){\r\n\t            nextEl.style.display = \'none\';\r\n\t          } else {\r\n\t            nextEl.style.display = \'block\';\r\n\t          }\r\n\t        }\r\n\t    });\r\n\t  })\r\n\t}\r\n\t// end if innerWidth\r\n}); \r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
