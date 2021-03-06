﻿using System.Web.Http;
using System.Web.Mvc;
using CAPPamari.Web.Helpers;
using CAPPamari.Web.Models;
using CAPPamari.Web.Models.Requests;

namespace CAPPamari.Web.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        ///     Login function for logging in a new user
        /// </summary>
        /// <param name="request">Request containing Username and Password of user to log in</param>
        /// <returns>ApplicationUserModel correxponding to the user if sign in was successful.</returns>
        [System.Web.Mvc.HttpPost]
        public JsonResult Login([FromBody] LoginRequest request)
        {
            var validationStatus = ValidationHelper.Validate(request.Username, request.Password);
            var badUser = ApplicationUserModel.InvalidUser();
            switch (validationStatus)
            {
                case ValidationStatus.BadInput:
                    return Json(ApiResponse<ApplicationUserModel>.FailureResponse("Bad input", badUser));
                case ValidationStatus.IncorrectPassword:
                    return Json(ApiResponse<ApplicationUserModel>.FailureResponse("Incorrect password", badUser));
                case ValidationStatus.InvalidSession:
                    return Json(ApiResponse<ApplicationUserModel>.FailureResponse("Invalid session", badUser));
                case ValidationStatus.NoSuchUsername:
                    return Json(ApiResponse<ApplicationUserModel>.FailureResponse("No such username exists", badUser));
                case ValidationStatus.Validated:
                    UserHelper.CreateUserSession(request.Username);
                    var user = UserHelper.GetApplicationUser(request.Username);
                    return Json(ApiResponse<ApplicationUserModel>.SuccessResponse("Logged in successfully", user));
            }
            return null;
        }

        /// <summary>
        ///     Log out function to log a user out.
        /// </summary>
        /// <param name="userName">Username of user to log out.</param>
        [System.Web.Mvc.HttpPost]
        public void Logout([FromBody] string userName)
        {
            UserHelper.DestroySession(userName);
        }

        /// <summary>
        ///     Register function to register a new user.
        /// </summary>
        /// <param name="request">RegistrationRequest containing pertinent user information for creation of the new user.</param>
        /// <returns>ApplicationUserModel corresponding to the newly created user and their session.</returns>
        [System.Web.Mvc.HttpPost]
        public JsonResult Register(RegistrationRequest request)
        {
            UserHelper.CreateNewUser(request.Username, request.Password, request.Major);
            UserHelper.CreateUserSession(request.Username);
            CourseHelper.CreateNewCappReport(request.Username, SupportedMajors.CSCI);
            var user = UserHelper.GetApplicationUser(request.Username);
            return Json(ApiResponse<ApplicationUserModel>.SuccessResponse("Registered successfully", user));
        }

        /// <summary>
        ///     Checks to see if a Username is already taken by another user.
        /// </summary>
        /// <param name="userName">Username to check for existence of in the database.</param>
        /// <returns>Bool denoting whether or not the userName is available.</returns>
        [System.Web.Mvc.HttpPost]
        public JsonResult CheckUsername(string userName)
        {
            return Json(ApiResponse<bool>.SuccessResponse("Username checked successfully", !EntitiesHelper.UsernameExists(userName)));
        }
    }
}