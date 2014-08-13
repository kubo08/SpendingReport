//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using WebGrease.Css.Extensions;

//namespace spending_report.Support
//{
//    public static class HtmlExtensions
//    {
//        public static void Repeater<T>(this HtmlHelper html
//  , IEnumerable<T> items
//  , Action<T> render
//  , Action<T> renderAlt)
//        {
//            if (items == null)
//                return;

//            int i = 0;
//            items.ForEach(item =>
//            {
//                if (i++ % 2 == 0)
//                    render(item);
//                else
//                    renderAlt(item);
//            });
//        }

//        public static void Repeater<T>(this HtmlHelper html
//          , Action<T> render
//          , Action<T> renderAlt)
//        {
//            var items = html.ViewContext.ViewData as IEnumerable<T>;
//            html.Repeater(items, render, renderAlt);
//        }

//        public static void Repeater<T>(this HtmlHelper html
//          , string viewDataKey
//          , Action<T> render
//          , Action<T> renderAlt)
//        {
//            var items = html.ViewContext.ViewData as IEnumerable<T>;
//            var viewData = html.ViewContext.ViewData as IDictionary<string, object>;
//            if (viewData != null)
//            {
//                items = viewData[viewDataKey] as IEnumerable<T>;
//            }
//            else
//            {
//                throw new NotImplementedException();
//                //items = new html.ViewContext.ViewData(viewData)[viewDataKey] as IEnumerable<T>;
//            }
//            html.Repeater(items, render, renderAlt);
//        }

//        //moje 

//        public static void Repeater<T>(this HtmlHelper html
//  , IEnumerable<T> items
//  , Action<T> render)
//        {
//            if (items == null)
//                return;

//            items.ForEach(render);
//        }
//    }
//}