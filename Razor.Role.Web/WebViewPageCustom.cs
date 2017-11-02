using mshtml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.WebPages;
using System.Xml;
using System.Xml.Linq;

namespace Razor.Role.Web
{
    public class WebViewPageCustom : System.Web.Mvc.WebViewPage
    {
        public override void Execute()
        {
        }

        private HelperResult Rewrite(HelperResult result)
        {
            //var stream = new StringWriter(new StringBuilder(result.ToHtmlString()));
            if (result == null)
                return null;

            IHTMLDocument2 docIn = (IHTMLDocument2)new HTMLDocument();

            var doc = result.ToHtmlString();
            docIn.write(doc);
            
            foreach (IHTMLElement el in docIn.all)
            {
                var attr = el.getAttribute("role");
                if (attr != null && !DBNull.Equals(attr, DBNull.Value) && attr.GetType() == typeof(string) && attr == ViewBag.Role)
                    ((IHTMLDOMNode)el).removeNode(true);
            }

            var docOut = docIn.body.parentElement.innerHTML;

            return new HelperResult(x => x.Write(docOut));
        }

        public override void Write(HelperResult result)
        {
            var res = (ViewBag.Role != null) ? Rewrite(result) : result;
            base.Write(res);
        }
    }


}