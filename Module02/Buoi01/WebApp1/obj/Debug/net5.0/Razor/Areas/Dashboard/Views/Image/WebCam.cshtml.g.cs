#pragma checksum "D:\TrungTamTinHoc_DHKH-TN\Module02\Buoi01\WebApp1\Areas\Dashboard\Views\Image\WebCam.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4d029ddd78d5071c052ea7ed803e86c2b46aa07"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Dashboard_Views_Image_WebCam), @"mvc.1.0.view", @"/Areas/Dashboard/Views/Image/WebCam.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4d029ddd78d5071c052ea7ed803e86c2b46aa07", @"/Areas/Dashboard/Views/Image/WebCam.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3b88d4eee74e5e5ee30f1386c0484a7440d3c48", @"/Areas/Dashboard/Views/_ViewImports.cshtml")]
    public class Areas_Dashboard_Views_Image_WebCam : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<button id=""open"">Open WebCam</button>
<button id=""close"">Close WebCam</button>
<button id=""tak"">Take Picture</button>
<video width=""100"" height=""100"" autoplay=""autoplay"" id=""vd""></video>
<canvas width=""100"" height=""100"" id=""cv""></canvas>
<script>
    var opt = {audio: false,video:{with:100,height:100}}
    $('#open').click(()=>{
        navigator.mediaDevices.getUserMedia(opt).then((stream)=>{
            vd.srcObject =stream;
        });
    });
    $('#close').click(()=>{
        var str = vd.srcObject;
        var tracks = str.getTracks();
        for(var i in tracks){
            tracks[i].stop();
        }
        vd.srcObject = null;
    });
    $('#tak').click(()={
        var ct = cv.getContext('2d');
        ct.drawImage(vd,0,0);
        var data = cv.toDataURL('image/png');
        //console.log(data);

        $.post('/dashboard/webcam',{f:data.substring(22)},(d)=>{
            //console.log(d);
            if (d==1){
                window.location.href='/dashboard/im");
            WriteLiteral("age\';\r\n            }\r\n        });\r\n    });\r\n</script>\r\n");
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
