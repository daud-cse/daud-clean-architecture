﻿using DotNet.ApplicationCore.Utils.Enum;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ApplicationCore.Utils.Helper
{
    public static class ClaimIdentityExtention
    {
        /// <summary>
        /// Get UserId of Current Logged User as Int32
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static async Task<string> GetUserIdFromClaimIdentity(this IPrincipal identity)
        {
            ClaimsIdentity claimsIdentity = identity.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(EnumClaimType.UserId.ToString());
            return await Task.FromResult(Convert.ToString(claim?.Value));
        }

        public static async Task<int> GetUserAutoIdFromClaimIdentity(this IPrincipal identity)
        {
            ClaimsIdentity claimsIdentity = identity.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(EnumClaimType.UserId.ToString());
            return await Task.FromResult(Convert.ToInt16(claim?.Value));
        }
        /// <summary>
        /// Get CompanyId of Current Logged User as Int32
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static async Task<int> GetOrginzationIdFromClaimIdentity(this IPrincipal identity)
        {
            ClaimsIdentity claimsIdentity = identity.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(EnumClaimType.OrganizationId.ToString());
            return await Task.FromResult(Convert.ToInt32(claim?.Value));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static async Task<int> GetBranchIdFromClaimIdentity(this IPrincipal identity)
        {
            ClaimsIdentity claimsIdentity = identity.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(EnumClaimType.BranchId.ToString());
            return await Task.FromResult(Convert.ToInt32(claim?.Value));
        }
        /// <summary>
        /// Get CompanyGuid of Current Logged User as string
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetCompanyGuidFromClaimIdentity(this IPrincipal identity)
        {
            ClaimsIdentity claimsIdentity = identity.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(EnumClaimType.CompanyGuid.ToString());
            return await Task.FromResult(claim?.Value);
        }
        /// <summary>
        /// Get Email of Current Logged User as string
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetEmailFromClaimIdentity(this IPrincipal identity)
        {
            ClaimsIdentity claimsIdentity = identity.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(EnumClaimType.Email.ToString());
            return await Task.FromResult(claim?.Value);
        }

        /// <summary>
        /// Get CompanyName of Current Logged User as string
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetCompanyNameFromClaimIdentity(this IPrincipal identity)
        {
            ClaimsIdentity claimsIdentity = identity.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(EnumClaimType.CompanyName.ToString());
            return await Task.FromResult(claim?.Value);
        }

        /// <summary>
        /// Get UserName of Current Logged User as string
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetUserNameFromClaimIdentity(this IPrincipal identity)
        {
            ClaimsIdentity claimsIdentity = identity.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(EnumClaimType.UserName.ToString());
            return await Task.FromResult(claim?.Value);
        }

        /// <summary>
        /// Get UserName of Current Logged User as string
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetUserFullNameFromClaimIdentity(this IPrincipal identity)
        {
            ClaimsIdentity claimsIdentity = identity.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(EnumClaimType.UserFullName.ToString());
            return await Task.FromResult(claim?.Value);
        }
        /// <summary>
        /// Get RightIds of Current Logged User as string
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetRoleIdFromClaimIdentity(this IPrincipal identity)
        {
            ClaimsIdentity claimsIdentity = identity.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(EnumClaimType.RoleId.ToString());
            return await Task.FromResult(claim?.Value);
        }
    }
}
