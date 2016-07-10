using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web;

namespace MyAspx.Framework.WebUnit.Common
{
    public class PagerNumber
    {//定义一个委托
        public delegate string ProcessDelegate(int iCurrentPage);
        public PagerNumber()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="count">总记录数</param>
        /// <param name="iPageSize">每页显示条数</param>
        /// <param name="iCurrentPage">当前页</param>
        /// <param name="webUrl">参数</param>
        /// <param name="IsAjax">是否用ＡＪＡＸ分页</param>
        /// <param name="aspxName">页面</param>
        /// <returns></returns>
        public string FunPager(int count, int iPageSize, int iCurrentPage, ProcessDelegate process, ProcessDelegate processPageSize=null)
        {
            //count = 800;
            //获取总的页数
            int pagernum1 = 0;
            if (count % iPageSize == 0)
            {
                pagernum1 = count / iPageSize;
            }
            else
            {
                pagernum1 = count / iPageSize + 1;
            }
            if (iCurrentPage > pagernum1)
            {
                iCurrentPage = 1;
            }
            string str = @" <ul><li class=""disabled""><a href=""#"">共有" + count + "条</a></li>";

            if (count == 0)
            {

            }
            else if (pagernum1 == 1)
            {
                str += @"<li class=""disabled""><a href=""#this"">首页</a></li>
                        <li class=""disabled""><a href=""#this"">上一页</a></li>
                        <li class=""active""><a href=""#this"">1</a> </li>
                        <li class=""disabled""><a href=""#"">下一页</a></li>
                        <li class=""disabled""><a href=""#"">最后页</a></li>";
            }
            else if (pagernum1 <= 10)
            {
                #region
                if (iCurrentPage == 1)
                {
                    str += @"<li class=""disabled""><a href=""#this"">首页</a></li>
                                <li class=""disabled""><a href=""#this"">上一页</a></li>";
                    for (int i = 1; i <= pagernum1; i++)
                    {
                        if (iCurrentPage == i)
                        {
                            str += @"<li class=""active""><a href=""#this"">"+i+@"</a> </li>";
                        }
                        else
                        {
                            str += @"<li><a " + PageA(i, process) + ">" + i + "</a></li>";
                        }
                    }
                    str += @"<li><a " + PageA(iCurrentPage + 1, process) + @">下一页</a></li>
                        <li><a " + PageA(pagernum1, process) + @">最后页</a></li>";
                }
                else if (iCurrentPage < pagernum1)
                {
                    str += @"<li><a " + PageA(1, process) + @">首页</a></li>
                             <li><a " + PageA(iCurrentPage - 1, process) + @">上一页</a></li>";
                    for (int i = 1; i <= pagernum1; i++)
                    {
                        if (iCurrentPage == i)
                        {
                            str += @"<li class=""active""><a href=""#this"">" + i + @"</a> </li>";
                        }
                        else
                        {
                            str += @"<li><a " + PageA(i, process) + ">" + i + "</a></li>";
                        }
                    }
                    str += @"<li><a " + PageA(iCurrentPage + 1, process) + @">下一页</a></li>
                        <li><a " + PageA(pagernum1, process) + @">最后页</a></li>";
                }
                else if (iCurrentPage == pagernum1)
                {
                    str += @"<li><a " + PageA(1, process) + @">首页</a></li>
                             <li><a " + PageA(iCurrentPage - 1, process) + @">上一页</a></li>";
                    for (int i = 1; i <= pagernum1; i++)
                    {
                        if (iCurrentPage == i)
                        {
                            str += @"<li class=""active""><a href=""#this"">" + i + @"</a> </li>";
                        }
                        else
                        {
                            str += @"<li><a " + PageA(i, process) + ">" + i + "</a></li>";
                        }
                    }
                    str += @" <li class=""disabled""><a href=""#"">下一页</a></li>
                        <li class=""disabled""><a href=""#"">最后页</a></li>";
                }
                #endregion
            }
            else if (pagernum1 > 10)
            {
                #region
                if (iCurrentPage == 1)
                {
                    str += @"<li class=""disabled""><a href=""#this"">首页</a></li>
                                <li class=""disabled""><a href=""#this"">上一页</a></li>";
                    for (int i = 1; i <= 11; i++)
                    {
                        if (i == 11)
                        {
                            str += @"<li><a " + PageA(i, process) + ">...</a></li>";
                        }
                        else
                        {
                            if (iCurrentPage == i)
                            {
                                str += @"<li class=""active""><a href=""#this"">" + i + @"</a> </li>";
                            }
                            else
                            {
                                str += @"<li><a " + PageA(i, process) + ">" + i + "</a></li>";
                            }
                        }
                    }
                    str += @"<li><a " + PageA(iCurrentPage + 1, process) + @">下一页</a></li>
                        <li><a " + PageA(pagernum1, process) + @">最后页</a></li>";
                }
                else if (iCurrentPage < pagernum1)
                {
                    int j = iCurrentPage / 10;
                    if (iCurrentPage % 10 == 0)
                    {
                        j = j - 1;
                    }
                    if (pagernum1 > (j * 10 + 11))
                    {
                       
                        str += @"<li><a " + PageA(1, process) + @">首页</a></li>
                             <li><a " + PageA(iCurrentPage - 1, process) + @">上一页</a></li>
                            <li><a " + PageA(j * 10 == 0 ? 1 : j * 10, process) + @">...</a></li>";
                        for (int i = j * 10 + 1; i <= j * 10 + 10; i++)
                        {
                            if (iCurrentPage == i)
                            {
                                str += @"<li class=""active""><a href=""#this"">" + i + @"</a> </li>";
                            }
                            else
                            {
                                str += @"<li><a " + PageA(i, process) + ">" + i + "</a></li>";
                            }
                        }
                        str += "<li><A " + PageA(j * 10 + 11, process) + ">...</A></li>";
                    }
                    else
                    {
                      
                        str += @"<li><a " + PageA(1, process) + @">首页</a></li>
                             <li><a " + PageA(iCurrentPage - 1, process) + @">上一页</a></li>
                            <li><a " + PageA(j * 10 == 0 ? 1 : j * 10, process) + @">...</a></li>";
                        for (int i = j * 10 + 1; i <= pagernum1; i++)
                        {
                            if (iCurrentPage == i)
                            {
                                str += @"<li class=""active""><a href=""#this"">" + i + @"</a> </li>";
                            }
                            else
                            {
                                str += @"<li><a " + PageA(i, process) + ">" + i + "</a></li>";
                            }
                        }

                    }
                    str += @"<li><a " + PageA(iCurrentPage + 1, process) + @">下一页</a></li>
                        <li><a " + PageA(pagernum1, process) + @">最后页</a></li>";
                }
                else if (iCurrentPage == pagernum1)
                {
                    int j = pagernum1 / 10;
                    if (iCurrentPage % 10 == 0)
                    {
                        j = j - 1;
                    }
                    str += @"<li><a " + PageA(1, process) + @">首页</a></li>
                             <li><a " + PageA(iCurrentPage - 1, process) + @">上一页</a></li>
                            <li><a " + PageA(j * 10 == 0 ? 1 : j * 10, process) + @">...</a></li>";

                  
                    for (int i = j * 10 + 1; i <= pagernum1; i++)
                    {
                        if (iCurrentPage == i)
                        {
                            str += @"<li class=""active""><a href=""#this"">" + i + @"</a> </li>";
                        }
                        else
                        {
                            str += @"<li><a " + PageA(i, process) + ">" + i + "</a></li>";
                        }
                    }

                    str += @" <li class=""disabled""><a href=""#"">下一页</a></li>
                        <li class=""disabled""><a href=""#"">最后页</a></li>";
                }
                #endregion
            }
            str += "</ul>";

            return str;
        }
        private string PageA(int iCurrentPage, ProcessDelegate process)
        {
            string sTemp = "";
            sTemp = process(iCurrentPage);
            return sTemp;
        }
        private string PageSize(int iPageSize, ProcessDelegate processPageSize)
        {
            string sTemp = "";
            sTemp = " 每页<select id='ddl_pagesize" + HttpContext.Current.Request["putype"] + @"' name='ddl_pagesize" + HttpContext.Current.Request["putype"] + @"' onchange='changepagesize" + HttpContext.Current.Request["putype"] + @"();' style='width:60px;'>";
            List<int> list = new List<int>();
            list.Add(15);
            list.Add(30);
            list.Add(50);
            list.Add(100);
            list.Add(200);
            if (list.Contains(iPageSize) == false)
                list.Add(iPageSize);
            list.Sort();
            foreach (int k in list)
            {
                if (iPageSize == k)
                {
                    sTemp += "<option value='" + k + "' selected='selected'>" + k + "</option>";
                }
                else
                {
                    sTemp += "<option value='" + k + "'>" + k + "</option>";
                }
            }
            sTemp += "</select>条 ";

            sTemp += @"
<script>
    function changepagesize" + HttpContext.Current.Request["putype"] + @"()
    {
          var pagesize = $('#ddl_pagesize" + HttpContext.Current.Request["putype"] + @"').val();
          " + processPageSize(iPageSize) + @"
    }
</script> 
";
            return sTemp;
        }

        public string FunPager_new(int count, int iPageSize, int iCurrentPage, ProcessDelegate process, ProcessDelegate processPageSize = null)
        {
            //获取总的页数
            int pagernum1 = 0;
            if (count % iPageSize == 0)
            {
                pagernum1 = count / iPageSize;
            }
            else
            {
                pagernum1 = count / iPageSize + 1;
            }
            if (iCurrentPage > pagernum1)
            {
                iCurrentPage = 1;
            }
            string str = "";

            if (count == 0)
            {

            }
            else if (pagernum1 == 1)
            {
                str += "<A style='' disabled><<</A><A style='' disabled><</A><SPAN style='' class=current>1</SPAN><A style='' disabled>></A><A style='' disabled>>></A>";
            }
            else if (pagernum1 <= 10)
            {
                #region
                if (iCurrentPage == 1)
                {
                    str += "<A style='' disabled><<</A><A style='' disabled><</A>";
                    for (int i = 1; i <= pagernum1; i++)
                    {
                        if (iCurrentPage == i)
                        {
                            str += "<SPAN style='' class=current>" + i + "</SPAN>";
                        }
                        else
                        {
                            str += "<A style='' " + PageA(i, process) + ">" + i + "</A>";
                        }
                    }
                    str += "<A style='' " + PageA(iCurrentPage + 1, process) + ">></A><A style=''  " + PageA(pagernum1, process) + " >>></A>";
                }
                else if (iCurrentPage < pagernum1)
                {
                    str += "<A style='' " + PageA(1, process) + "><<</A><A style='' " + PageA(iCurrentPage - 1, process) + "><</A>";
                    for (int i = 1; i <= pagernum1; i++)
                    {
                        if (iCurrentPage == i)
                        {
                            str += "<SPAN style='' class=current>" + i + "</SPAN>";
                        }
                        else
                        {
                            str += "<A style='' " + PageA(i, process) + ">" + i + "</A>";
                        }
                    }
                    str += "<A style='' " + PageA(iCurrentPage + 1, process) + ">></A><A style=''  " + PageA(pagernum1, process) + " >>></A>";
                }
                else if (iCurrentPage == pagernum1)
                {
                    str += "<A style='' " + PageA(1, process) + "><<</A><A style='' " + PageA(iCurrentPage - 1, process) + "><</A>";
                    for (int i = 1; i <= pagernum1; i++)
                    {
                        if (iCurrentPage == i)
                        {
                            str += "<SPAN style='' class=current>" + i + "</SPAN>";
                        }
                        else
                        {
                            str += "<A style='' " + PageA(i, process) + ">" + i + "</A>";
                        }
                    }
                    str += "<A style='' disabled>></A><A style='' disabled>>></A>";
                }
                #endregion
            }
            else if (pagernum1 > 10)
            {
                #region
                if (iCurrentPage == 1)
                {
                    str += "<A style='' disabled><<</A><A style='' disabled><</A>";
                    for (int i = 1; i <= 11; i++)
                    {
                        if (i == 11)
                        {
                            str += "<A style='' " + PageA(i, process) + ">...</A>";
                        }
                        else
                        {
                            if (iCurrentPage == i)
                            {
                                str += "<SPAN style='' class=current>" + i + "</SPAN>";
                            }
                            else
                            {
                                str += "<A style='' " + PageA(i, process) + ">" + i + "</A>";
                            }
                        }
                    }
                    str += "<A style='' " + PageA(iCurrentPage + 1, process) + ">></A><A style=''  " + PageA(pagernum1, process) + " >>></A>";
                }
                else if (iCurrentPage < pagernum1)
                {
                    int j = iCurrentPage / 10;
                    if (iCurrentPage % 10 == 0)
                    {
                        j = j - 1;
                    }
                    if (pagernum1 > (j * 10 + 11))
                    {
                        str += "<A style='' " + PageA(1, process) + "><<</A><A style='' " + PageA(iCurrentPage - 1, process) + "><</A><A style='' " + PageA(j * 10 == 0 ? 1 : j * 10, process) + ">...</A>";
                        for (int i = j * 10 + 1; i <= j * 10 + 10; i++)
                        {
                            if (iCurrentPage == i)
                            {
                                str += "<SPAN style='' class=current>" + i + "</SPAN>";
                            }
                            else
                            {
                                str += "<A style='' " + PageA(i, process) + ">" + i + "</A>";
                            }
                        }
                        str += "<A style='' " + PageA(j * 10 + 11, process) + ">...</A>";
                    }
                    else
                    {
                        str += "<A style='' " + PageA(1, process) + "><<</A><A style='' " + PageA(iCurrentPage - 1, process) + "><</A><A style='' " + PageA(j * 10 == 0 ? 1 : j * 10, process) + ">...</A>";
                        for (int i = j * 10 + 1; i <= pagernum1; i++)
                        {
                            if (iCurrentPage == i)
                            {
                                str += "<SPAN style='' class=current>" + i + "</SPAN>";
                            }
                            else
                            {
                                str += "<A style='' " + PageA(i, process) + ">" + i + "</A>";
                            }
                        }

                    }

                    str += "<A style='' " + PageA(iCurrentPage + 1, process) + ">></A><A style=''  " + PageA(pagernum1, process) + " >>></A>";
                }
                else if (iCurrentPage == pagernum1)
                {
                    int j = pagernum1 / 10;
                    if (iCurrentPage % 10 == 0)
                    {
                        j = j - 1;
                    }

                    str += "<A style='' " + PageA(1, process) + "><<</A><A style='' " + PageA(iCurrentPage - 1, process) + "><</A><A style='' " + PageA(j * 10 == 0 ? 1 : j * 10, process) + ">...</A>";
                    for (int i = j * 10 + 1; i <= pagernum1; i++)
                    {
                        if (iCurrentPage == i)
                        {
                            str += "<SPAN style='' class=current>" + i + "</SPAN>";
                        }
                        else
                        {
                            str += "<A style='' " + PageA(i, process) + ">" + i + "</A>";
                        }
                    }

                    str += "<A style='' disabled>></A><A style='' disabled>>></A>";
                }
                #endregion
            }
            str += "<SPAN style='FONT-SIZE: 14px'>共有记录" + count + @"条 " + (processPageSize != null ? PageSize(iPageSize, processPageSize) : "") + "</SPAN>";

            return str;
        }
    }
}
