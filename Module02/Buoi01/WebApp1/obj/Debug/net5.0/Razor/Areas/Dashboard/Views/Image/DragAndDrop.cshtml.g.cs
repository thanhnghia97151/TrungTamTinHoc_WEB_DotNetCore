#pragma checksum "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Areas\Dashboard\Views\Image\DragAndDrop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3baba2b623c14a27ee21dab84d3a03158bc60622"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Dashboard_Views_Image_DragAndDrop), @"mvc.1.0.view", @"/Areas/Dashboard/Views/Image/DragAndDrop.cshtml")]
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
#line 2 "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Areas\Dashboard\Views\_ViewImports.cshtml"
using WebApp1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3baba2b623c14a27ee21dab84d3a03158bc60622", @"/Areas/Dashboard/Views/Image/DragAndDrop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3b88d4eee74e5e5ee30f1386c0484a7440d3c48", @"/Areas/Dashboard/Views/_ViewImports.cshtml")]
    public class Areas_Dashboard_Views_Image_DragAndDrop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div ondrop=""dropHandler(event)"" ondragover=""dragoverHandler(event)"" id=""zone"">
    Drop Zone
</div>
<style>
    #zone{
        border: 1px solid #ddd;
        width:300px;
        height: 270px;
        text-align:center;
        background-color:bisque;
    }
</style>
<script>
    function dropHandler(ev){
        ev.preventDefault();// chặn chuyển qua trang khác
        //console.log(ev.dataTransfer.files);
        var files = ev.dataTransfer.files;
        var fd = new FormData();
        for(var i= 0;i<files.length;i++){
            fd.append('af',files[i]);
        }
        $.post({
            url: '/dashboard/image/draganddrop',
            method: 'post',
            data: fd,
            contentType:false,
            processData:false,
         
            success: (d)=>{
                //console.log(d); 
                if(d>0){
                    window.location.href = '/dashboard/image';
                }
            }
        });
    }
    function dragov");
            WriteLiteral("erHandler(ev){\r\n        ev.preventDefault();\r\n    }\r\n</script>");
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
