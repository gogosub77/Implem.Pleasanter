﻿using Implem.Pleasanter.Libraries.Requests;
using Implem.Pleasanter.Models;
using System.Web.Mvc;
namespace Implem.Pleasanter.Controllers
{
    [Authorize]
    [ValidateInput(false)]
    public class ItemsController : Controller
    {
        [HttpGet]
        public ActionResult Index(long id = 0)
        {
            var log = new SysLogModel();
            var html = new ItemModel(id).Index();
            ViewBag.HtmlBody = html;
            log.Finish(html.Length);
            return View();
        }

        [HttpGet]
        public ActionResult New(long id = 0)
        {
            var log = new SysLogModel();
            var itemModel = new ItemModel(id);
            var html = itemModel.New();
            ViewBag.HtmlBody = html;
            log.Finish(html.Length);
            return View();
        }

        [HttpPost]
        public string NewByLink(long id = 0)
        {
            var log = new SysLogModel();
            var itemModel = new ItemModel(id);
            var json = itemModel.NewByLink();
            log.Finish(json.Length);
            return json;
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var log = new SysLogModel();
            var itemModel = new ItemModel(id);
            var html = itemModel.Edit();
            ViewBag.HtmlBody = html;
            log.Finish(html.Length);
            return View();
        }

        [HttpPost]
        public string Import(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).Import();
            log.Finish(json.Length);
            return json;
        }

        [HttpGet]
        public ActionResult Export(long id)
        {
            var log = new SysLogModel();
            var responseFile = new ItemModel(id).Export();
            log.Finish(responseFile.Length);
            return responseFile.ToFile();
        }

        [HttpGet]
        public ActionResult Search()
        {
            var log = new SysLogModel();
            var html = SearchIndexesUtility.Search();
            ViewBag.HtmlBody = html;
            log.Finish(html.Length);
            return View();
        }

        [HttpGet]
        public string AjaxSearch()
        {
            var log = new SysLogModel();
            var json = SearchIndexesUtility.AjaxSearch();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string DataView(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).DataView();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string GridRows(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).GridRows();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string Create(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).Create();
            log.Finish(json.Length);
            return json;
        }

        [HttpPut]
        public string Update(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).Update();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string Copy(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).Copy();
            log.Finish(json.Length);
            return json;
        }

        [HttpGet]
        public string MoveTargets(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).MoveTargets();
            log.Finish(json.Length);
            return json;
        }

        [HttpPut]
        public string Move(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).Move();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string MoveSiteMenu(long id)
        {
            var log = new SysLogModel();
            var json = new SiteModel(id).MoveSiteMenu(Forms.Long("SiteId"));
            log.Finish(json.Length);
            return json;
        }

        [HttpPut]
        public string SortSiteMenu(long id)
        {
            var log = new SysLogModel();
            var json = new SiteModel(id).SortSiteMenu();
            log.Finish(json.Length);
            return json;
        }

        [HttpPut]
        public string BulkMove(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).BulkMove();
            log.Finish(json.Length);
            return json;
        }

        [HttpDelete]
        public string Delete(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).Delete();
            log.Finish(json.Length);
            return json;
        }

        [HttpDelete]
        public string BulkDelete(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).BulkDelete();
            log.Finish(json.Length);
            return json;
        }

        [HttpDelete]
        public string DeleteComment(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).DeleteComment();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string Restore(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel().Restore(id);
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string EditSeparateSettings(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).EditSeparateSettings();
            log.Finish(json.Length);
            return json;
        }

        [HttpPut]
        public string Separate(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).Separate();
            log.Finish(json.Length);
            return json;
        }

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Post | HttpVerbs.Delete)]
        public string SetSiteSettings(long id)
        {
            var log = new SysLogModel();
            var json = new SiteModel(id).SetSiteSettings();
            log.Finish(json.Length);
            return json;
        }

        [HttpGet]
        public string Histories(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).Histories();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string History(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).History();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string PreviousHistory(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).PreviousHistory();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string NextHistory(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).NextHistory();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string Previous(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).Previous();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string Next(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).Next();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string Reload(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).Reload();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string BurnDownRecordDetails(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).BurnDownRecordDetails();
            log.Finish(json.Length);
            return json;
        }

        [HttpPut]
        public string SynchronizeSummary(long id)
        {
            var log = new SysLogModel();
            var json = new ItemModel(id).SynchronizeSummary();
            log.Finish(json.Length);
            return json;
        }
    }
}