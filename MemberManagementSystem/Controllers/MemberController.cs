﻿using MemberManagementSystem.Models;
using MemberManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MemberManagementSystem.Controllers
{
    public class MemberController : Controller
    {
        MemberService memberService = new MemberService();
        // GET: Member
        public ActionResult Index()
        {
            return View(memberService.GetAllMember());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member Data)
        {
            memberService.InsertMemeberData(Data);
            return RedirectToAction("Index", "Member");
        }

        public ActionResult EditView(int Id)
        {
            return PartialView(memberService.GetMemberById(Id));
        }

        [HttpPost]
        public ActionResult Edit(Member MemberData)
        {
                memberService.EditMemberData(MemberData);
                return RedirectToAction("Index","Member");
        }

        public ActionResult Delete(int Id)
        {
            memberService.DeleteMemberData(Id);
            return RedirectToAction("index");
        }

    }
}