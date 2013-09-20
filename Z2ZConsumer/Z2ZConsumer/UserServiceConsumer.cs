﻿using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace Z2Z
{
    /// <summary>
    /// A collection of static methods, each directly associated with a remote WebMethod. Each static method takes two arguments,
    /// the requesting user and the object that must be operated upon, and calls the specialized ServiceCall method with both arguments
    /// and the name of the corresponding web method.
    /// </summary>
    public class UserServiceConsumer
    {

        #region Client Service Calls

        /// <summary>
        ///   Gets a specified <see cref="Client"/> by key.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aClient"><see cref="Client"/> object.</param>
        public static void GetClient(UserToken aUserToken, Client aClient)
        {
            UserCallHandler.ServiceCall<Client>(aUserToken, "GetClient", aClient);
        }

        /// <summary>
        ///   Gets a specified <see cref="ClientCollection"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aClientCollection"><see cref="Client"/>Collection object.</param>
        public static void GetClientCollection(UserToken aUserToken, ClientCollection aClientCollection)
        {
            UserCallHandler.ServiceCall<ClientCollection>(aUserToken, "GetClientCollection", aClientCollection);
        }

        /// <summary>
        ///   Add a <see cref="Client"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aClient"><see cref="Client"/> object.</param>
        public static void AddClient(UserToken aUserToken, Client aClient)
        {
            UserCallHandler.ServiceCall<Client>(aUserToken, "AddClient", aClient);
        }

        /// <summary>
        ///   Edit a specified <see cref="Client"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aClient"><see cref="Client"/> object.</param>
        public static void EditClient(UserToken aUserToken, Client aClient)
        {
            UserCallHandler.ServiceCall<Client>(aUserToken, "EditClient", aClient);
        }

        /// <summary>
        ///   Delete a specified <see cref="Client"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aClient"><see cref="Client"/> object.</param>
        public static void DeleteClient(UserToken aUserToken, Client aClient)
        {
            UserCallHandler.ServiceCall<Client>(aUserToken, "DeleteClient", aClient);
        }

        #endregion

        #region Contributor Service Calls

        /// <summary>
        ///   Gets a specified <see cref="Contributor"/> by key.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aContributor"><see cref="Contributor"/> object.</param>
        public static void GetContributor(UserToken aUserToken, Contributor aContributor)
        {
            UserCallHandler.ServiceCall<Contributor>(aUserToken, "GetContributor", aContributor);
        }

        /// <summary>
        ///   Gets a specified <see cref="ContributorCollection"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aContributorCollection"><see cref="Contributor"/>Collection object.</param>
        public static void GetContributorCollection(UserToken aUserToken, ContributorCollection aContributorCollection)
        {
            UserCallHandler.ServiceCall<ContributorCollection>(aUserToken, "GetContributorCollection", aContributorCollection);
        }

        /// <summary>
        ///   Add a <see cref="Contributor"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aContributor"><see cref="Contributor"/> object.</param>
        public static void AddContributor(UserToken aUserToken, Contributor aContributor)
        {
            UserCallHandler.ServiceCall<Contributor>(aUserToken, "AddContributor", aContributor);
        }

        /// <summary>
        ///   Edit a specified <see cref="Contributor"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aContributor"><see cref="Contributor"/> object.</param>
        public static void EditContributor(UserToken aUserToken, Contributor aContributor)
        {
            UserCallHandler.ServiceCall<Contributor>(aUserToken, "EditContributor", aContributor);
        }

        /// <summary>
        ///   Delete a specified <see cref="Contributor"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aContributor"><see cref="Contributor"/> object.</param>
        public static void DeleteContributor(UserToken aUserToken, Contributor aContributor)
        {
            UserCallHandler.ServiceCall<Contributor>(aUserToken, "DeleteContributor", aContributor);
        }

        #endregion

        #region ContributorLanguage Service Calls

        /// <summary>
        ///   Gets a specified <see cref="ContributorLanguage"/> by key.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aContributorLanguage"><see cref="ContributorLanguage"/> object.</param>
        public static void GetContributorLanguage(UserToken aUserToken, ContributorLanguage aContributorLanguage)
        {
            UserCallHandler.ServiceCall<ContributorLanguage>(aUserToken, "GetContributorLanguage", aContributorLanguage);
        }

        /// <summary>
        ///   Gets a specified <see cref="ContributorLanguageCollection"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aContributorLanguageCollection"><see cref="ContributorLanguage"/>Collection object.</param>
        public static void GetContributorLanguageCollection(UserToken aUserToken, ContributorLanguageCollection aContributorLanguageCollection)
        {
            UserCallHandler.ServiceCall<ContributorLanguageCollection>(aUserToken, "GetContributorLanguageCollection", aContributorLanguageCollection);
        }

        /// <summary>
        ///   Add a <see cref="ContributorLanguage"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aContributorLanguage"><see cref="ContributorLanguage"/> object.</param>
        public static void AddContributorLanguage(UserToken aUserToken, ContributorLanguage aContributorLanguage)
        {
            UserCallHandler.ServiceCall<ContributorLanguage>(aUserToken, "AddContributorLanguage", aContributorLanguage);
        }

        /// <summary>
        ///   Edit a specified <see cref="ContributorLanguage"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aContributorLanguage"><see cref="ContributorLanguage"/> object.</param>
        public static void EditContributorLanguage(UserToken aUserToken, ContributorLanguage aContributorLanguage)
        {
            UserCallHandler.ServiceCall<ContributorLanguage>(aUserToken, "EditContributorLanguage", aContributorLanguage);
        }

        /// <summary>
        ///   Delete a specified <see cref="ContributorLanguage"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aContributorLanguage"><see cref="ContributorLanguage"/> object.</param>
        public static void DeleteContributorLanguage(UserToken aUserToken, ContributorLanguage aContributorLanguage)
        {
            UserCallHandler.ServiceCall<ContributorLanguage>(aUserToken, "DeleteContributorLanguage", aContributorLanguage);
        }

        #endregion

        #region Document Service Calls

        /// <summary>
        ///   Gets a specified <see cref="Document"/> by key.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aDocument"><see cref="Document"/> object.</param>
        public static void GetDocument(UserToken aUserToken, Document aDocument)
        {
            UserCallHandler.ServiceCall<Document>(aUserToken, "GetDocument", aDocument);
        }

        /// <summary>
        ///   Gets a specified <see cref="DocumentCollection"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aDocumentCollection"><see cref="Document"/>Collection object.</param>
        public static void GetDocumentCollection(UserToken aUserToken, DocumentCollection aDocumentCollection)
        {
            UserCallHandler.ServiceCall<DocumentCollection>(aUserToken, "GetDocumentCollection", aDocumentCollection);
        }

        /// <summary>
        ///   Add a <see cref="Document"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aDocument"><see cref="Document"/> object.</param>
        public static void AddDocument(UserToken aUserToken, Document aDocument)
        {
            UserCallHandler.ServiceCall<Document>(aUserToken, "AddDocument", aDocument);
        }

        /// <summary>
        ///   Edit a specified <see cref="Document"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aDocument"><see cref="Document"/> object.</param>
        public static void EditDocument(UserToken aUserToken, Document aDocument)
        {
            UserCallHandler.ServiceCall<Document>(aUserToken, "EditDocument", aDocument);
        }

        /// <summary>
        ///   Delete a specified <see cref="Document"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aDocument"><see cref="Document"/> object.</param>
        public static void DeleteDocument(UserToken aUserToken, Document aDocument)
        {
            UserCallHandler.ServiceCall<Document>(aUserToken, "DeleteDocument", aDocument);
        }

        #endregion

        #region JobType Service Calls

        /// <summary>
        ///   Gets a specified <see cref="JobType"/> by key.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aJobType"><see cref="JobType"/> object.</param>
        public static void GetJobType(UserToken aUserToken, JobType aJobType)
        {
            UserCallHandler.ServiceCall<JobType>(aUserToken, "GetJobType", aJobType);
        }

        /// <summary>
        ///   Gets a specified <see cref="JobTypeCollection"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aJobTypeCollection"><see cref="JobType"/>Collection object.</param>
        public static void GetJobTypeCollection(UserToken aUserToken, JobTypeCollection aJobTypeCollection)
        {
            UserCallHandler.ServiceCall<JobTypeCollection>(aUserToken, "GetJobTypeCollection", aJobTypeCollection);
        }

        /// <summary>
        ///   Add a <see cref="JobType"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aJobType"><see cref="JobType"/> object.</param>
        public static void AddJobType(UserToken aUserToken, JobType aJobType)
        {
            UserCallHandler.ServiceCall<JobType>(aUserToken, "AddJobType", aJobType);
        }

        /// <summary>
        ///   Edit a specified <see cref="JobType"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aJobType"><see cref="JobType"/> object.</param>
        public static void EditJobType(UserToken aUserToken, JobType aJobType)
        {
            UserCallHandler.ServiceCall<JobType>(aUserToken, "EditJobType", aJobType);
        }

        /// <summary>
        ///   Delete a specified <see cref="JobType"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aJobType"><see cref="JobType"/> object.</param>
        public static void DeleteJobType(UserToken aUserToken, JobType aJobType)
        {
            UserCallHandler.ServiceCall<JobType>(aUserToken, "DeleteJobType", aJobType);
        }

        #endregion

        #region Job Service Calls

        /// <summary>
        ///   Gets a specified <see cref="Job"/> by key.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aJob"><see cref="Job"/> object.</param>
        public static void GetJob(UserToken aUserToken, Job aJob)
        {
            UserCallHandler.ServiceCall<Job>(aUserToken, "GetJob", aJob);
        }

        /// <summary>
        ///   Gets a specified <see cref="JobCollection"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aJobCollection"><see cref="Job"/>Collection object.</param>
        public static void GetJobCollection(UserToken aUserToken, JobCollection aJobCollection)
        {
            UserCallHandler.ServiceCall<JobCollection>(aUserToken, "GetJobCollection", aJobCollection);
        }

        /// <summary>
        ///   Add a <see cref="Job"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aJob"><see cref="Job"/> object.</param>
        public static void AddJob(UserToken aUserToken, Job aJob)
        {
            UserCallHandler.ServiceCall<Job>(aUserToken, "AddJob", aJob);
        }

        /// <summary>
        ///   Edit a specified <see cref="Job"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aJob"><see cref="Job"/> object.</param>
        public static void EditJob(UserToken aUserToken, Job aJob)
        {
            UserCallHandler.ServiceCall<Job>(aUserToken, "EditJob", aJob);
        }

        /// <summary>
        ///   Edit a specified <see cref="Job"/> including updating its Status Date.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aJob"><see cref="Job"/> object.</param>
        public static void EditJobStatusDate(UserToken aUserToken, Job aJob)
        {
            UserCallHandler.ServiceCall<Job>(aUserToken, "EditJobStatusDate", aJob);
        }
        
        /// <summary>
        ///   Delete a specified <see cref="Job"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aJob"><see cref="Job"/> object.</param>
        public static void DeleteJob(UserToken aUserToken, Job aJob)
        {
            UserCallHandler.ServiceCall<Job>(aUserToken, "DeleteJob", aJob);
        }

        #endregion

        #region Language Service Calls

        /// <summary>
        ///   Gets a specified <see cref="Language"/> by key.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aLanguage"><see cref="Language"/> object.</param>
        public static void GetLanguage(UserToken aUserToken, Language aLanguage)
        {
            UserCallHandler.ServiceCall<Language>(aUserToken, "GetLanguage", aLanguage);
        }

        /// <summary>
        ///   Gets a specified <see cref="LanguageCollection"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aLanguageCollection"><see cref="Language"/>Collection object.</param>
        public static void GetLanguageCollection(UserToken aUserToken, LanguageCollection aLanguageCollection)
        {
            UserCallHandler.ServiceCall<LanguageCollection>(aUserToken, "GetLanguageCollection", aLanguageCollection);
        }

        /// <summary>
        ///   Add a <see cref="Language"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aLanguage"><see cref="Language"/> object.</param>
        public static void AddLanguage(UserToken aUserToken, Language aLanguage)
        {
            UserCallHandler.ServiceCall<Language>(aUserToken, "AddLanguage", aLanguage);
        }

        /// <summary>
        ///   Edit a specified <see cref="Language"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aLanguage"><see cref="Language"/> object.</param>
        public static void EditLanguage(UserToken aUserToken, Language aLanguage)
        {
            UserCallHandler.ServiceCall<Language>(aUserToken, "EditLanguage", aLanguage);
        }

        /// <summary>
        ///   Delete a specified <see cref="Language"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aLanguage"><see cref="Language"/> object.</param>
        public static void DeleteLanguage(UserToken aUserToken, Language aLanguage)
        {
            UserCallHandler.ServiceCall<Language>(aUserToken, "DeleteLanguage", aLanguage);
        }

        #endregion

        #region WorkItem Service Calls

        /// <summary>
        ///   Gets a specified <see cref="WorkItem"/> by key.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aWorkItem"><see cref="WorkItem"/> object.</param>
        public static void GetWorkItem(UserToken aUserToken, WorkItem aWorkItem)
        {
            UserCallHandler.ServiceCall<WorkItem>(aUserToken, "GetWorkItem", aWorkItem);
        }

        /// <summary>
        ///   Gets a specified <see cref="WorkItemCollection"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aWorkItemCollection"><see cref="WorkItem"/>Collection object.</param>
        public static void GetWorkItemCollection(UserToken aUserToken, WorkItemCollection aWorkItemCollection)
        {
            UserCallHandler.ServiceCall<WorkItemCollection>(aUserToken, "GetWorkItemCollection", aWorkItemCollection);
        }

        /// <summary>
        ///   Add a <see cref="WorkItem"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aWorkItem"><see cref="WorkItem"/> object.</param>
        public static void AddWorkItem(UserToken aUserToken, WorkItem aWorkItem)
        {
            UserCallHandler.ServiceCall<WorkItem>(aUserToken, "AddWorkItem", aWorkItem);
        }

        /// <summary>
        ///   Edit a specified <see cref="WorkItem"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aWorkItem"><see cref="WorkItem"/> object.</param>
        public static void EditWorkItem(UserToken aUserToken, WorkItem aWorkItem)
        {
            UserCallHandler.ServiceCall<WorkItem>(aUserToken, "EditWorkItem", aWorkItem);
        }

        /// <summary>
        ///   Delete a specified <see cref="WorkItem"/>.
        /// </summary>
        /// <param name="aUserToken">A <see cref="UserToken"/> object used for Access Control.</param>
        /// <param name="aWorkItem"><see cref="WorkItem"/> object.</param>
        public static void DeleteWorkItem(UserToken aUserToken, WorkItem aWorkItem)
        {
            UserCallHandler.ServiceCall<WorkItem>(aUserToken, "DeleteWorkItem", aWorkItem);
        }

        #endregion

        #region Role Service Calls

        /// <summary>
        ///   Gets a specified <see cref="Role"/> by key.
        /// </summary>
        /// <param name="aRole"><see cref="Role"/> object.</param>
        /// <param name="aUserToken">A user token.</param>
        public static void GetRole(UserToken aUserToken, Role aRole)
        {
            UserCallHandler.ServiceCall<Role>(aUserToken, "GetRole", aRole);
        }

        /// <summary>
        ///   Gets a specified <see cref="RoleCollection"/>.
        /// </summary>
        /// <param name="aRoleCollection"><see cref="Role"/>Collection object.</param>
        /// <param name="aUserToken">A user token.</param>
        public static void GetRoleCollection(UserToken aUserToken, RoleCollection aRoleCollection)
        {
            UserCallHandler.ServiceCall<RoleCollection>(aUserToken, "GetRoleCollection", aRoleCollection);
        }

        /// <summary>
        ///   Add a <see cref="Role"/>.
        /// </summary>
        /// <param name="aRole"><see cref="Role"/> object.</param>
        /// <param name="aUserToken">A user token.</param>
        public static void AddRole(UserToken aUserToken, Role aRole)
        {
            UserCallHandler.ServiceCall<Role>(aUserToken, "AddRole", aRole);
        }

        /// <summary>
        ///   Edit a specified <see cref="Role"/>.
        /// </summary>
        /// <param name="aRole"><see cref="Role"/> object.</param>
        /// <param name="aUserToken">A user token.</param>
        public static void EditRole(UserToken aUserToken, Role aRole)
        {
            UserCallHandler.ServiceCall<Role>(aUserToken, "EditRole", aRole);
        }

        /// <summary>
        ///   Delete a specified <see cref="Role"/>.
        /// </summary>
        /// <param name="aRole"><see cref="Role"/> object.</param>
        /// <param name="aUserToken">A user token.</param>
        public static void DeleteRole(UserToken aUserToken, Role aRole)
        {
            UserCallHandler.ServiceCall<Role>(aUserToken, "DeleteRole", aRole);
        }

        #endregion

        #region RoleFunctionEditor Service Calls

        /// <summary>
        ///   Get a specified <see cref="RoleFunctionEditor"/>.
        /// </summary>
        /// <param name="aRoleFunctionEditor">A <see cref="RoleFunctionEditor"/> object.</param>
        /// <param name="aUserToken">A user token.</param>
        //public static void GetRoleFunctionEditor(UserToken aUserToken, RoleFunctionEditor aRoleFunctionEditor)
        //{
        //    UserCallHandler.ServiceCall<RoleFunctionEditor>(aUserToken, "GetRoleFunctionEditor", aRoleFunctionEditor);
        //}

        /// <summary>
        ///   Put a specified <see cref="RoleFunctionEditor"/>.
        /// </summary>
        /// <param name="aRoleFunctionEditor">A <see cref="RoleFunctionEditor"/> object.</param>
        /// <param name="aUserToken">A user token.</param>
        //public static void PutRoleFunctionEditor(UserToken aUserToken, RoleFunctionEditor aRoleFunctionEditor)
        //{
        //    UserCallHandler.ServiceCall<RoleFunctionEditor>(aUserToken, "PutRoleFunctionEditor", aRoleFunctionEditor);
        //}

        #endregion

        #region User Service Calls
        
        /// <summary>
        /// Call the WebService with a request to return a User with a specified UserID
        /// </summary>
        /// <param name="aUser">The User object to return</param>
        /// <param name="aUserToken">A user token.</param>
        public static void GetUserByID(UserToken aUserToken, User aUser)
        {
            UserCallHandler.ServiceCall<User>(aUserToken, "GetUserByID", aUser);
        }

        /// <summary>
        /// Call the WebService with a request to return a User with a specified UserKey
        /// </summary>
        /// <param name="aUser">The User object to return</param>
        /// <param name="aUserToken">A user token.</param>
        public static void GetUser(UserToken aUserToken, User aUser)
        {
            UserCallHandler.ServiceCall<User>(aUserToken, "GetUser", aUser);
        }

        /// <summary>
        /// Gets a UserCollection
        /// </summary>
        /// <param name="aUserToken">A user token.</param>
        /// <param name="aUserCollection">A user collection.</param>
        public static void GetUserCollection(UserToken aUserToken, UserCollection aUserCollection)
        {
            UserCallHandler.ServiceCall<UserCollection>(aUserToken, "GetUserCollection", aUserCollection);
        }

        /// <summary>
        /// Call the WebService with a request to Add a User
        /// </summary>
        /// <param name="aUser">The User object to Add</param>
        /// <param name="aUserToken">A user token.</param>
        public static void AddUser(UserToken aUserToken, User aUser)
        {
            UserCallHandler.ServiceCall<User>(aUserToken, "AddUser", aUser);
        }

        /// <summary>
        /// Call the WebService with a request to Edit a User
        /// </summary>
        /// <param name="aUser">The User object to Edit</param>
        /// <param name="aUserToken">A user token.</param>
        public static void EditUser(UserToken aUserToken, User aUser)
        {
            UserCallHandler.ServiceCall<User>(aUserToken, "EditUser", aUser);
        }

        /// <summary>
        /// Call the WebService with a request to Delete a User
        /// </summary>
        /// <param name="aUser">The User object to Delete</param>
        /// <param name="aUserToken">A user token.</param>
        public static void DeleteUser(UserToken aUserToken, User aUser)
        {
            UserCallHandler.ServiceCall<User>(aUserToken, "DeleteUser", aUser);
        }
        #endregion

        #region UserFunctionAccess Service Calls
        /// <summary>
        /// Get a specific <see cref="UserFunctionAccess"/>.
        /// </summary>
        /// <param name="aUserToken">A user token.</param>
        /// <param name="aUserFunctionAccess">The UserFunctionAccess to return</param>
        public static void GetUserFunctionAccessCollection(UserToken aUserToken, UserFunctionAccess aUserFunctionAccess)
        {
            UserCallHandler.ServiceCall<UserFunctionAccess>(aUserToken, "GetUserFunctionAccess", aUserFunctionAccess);
        }

        /// <summary>
        /// Get a Collection of <see cref="UserFunctionAccess"/>.
        /// </summary>
        /// <param name="aUserToken">A user token.</param>
        /// <param name="aUserFunctionAccessCollection">The UserFunctionAccessCollection containing the List to return</param>
        public static void GetUserFunctionAccessCollection(UserToken aUserToken, UserFunctionAccessCollection aUserFunctionAccessCollection)
        {
            UserCallHandler.ServiceCall<UserFunctionAccessCollection>(aUserToken, "GetUserFunctionAccessCollection", aUserFunctionAccessCollection);
        }
        #endregion

        #region UserRoleEditor Service Calls

        /// <summary>
        /// Gets a <see cref="UserRoleEditor"/> from the Ruci SOAP Service
        /// </summary>
        /// <param name="aUserToken">A user token.</param>
        /// <param name="aUserRoleEditor">A user role editor.</param>
        //public static void GetUserRoleEditor(UserToken aUserToken, UserRoleEditor aUserRoleEditor)
        //{
        //    UserCallHandler.ServiceCall<UserRoleEditor>(aUserToken, "GetUserRoleEditor", aUserRoleEditor);
        //}

        /// <summary>
        /// Puts a <see cref="UserRoleEditor"/> via the Ruci SOAP Service
        /// </summary>
        /// <param name="aUserToken">A user token.</param>
        /// <param name="aUserRoleEditor">A user role editor.</param>
        //public static void PutUserRoleEditor(UserToken aUserToken, UserRoleEditor aUserRoleEditor)
        //{
        //    UserCallHandler.ServiceCall<UserRoleEditor>(aUserToken, "PutUserRoleEditor", aUserRoleEditor);
        //}

        #endregion
        
    }
}
