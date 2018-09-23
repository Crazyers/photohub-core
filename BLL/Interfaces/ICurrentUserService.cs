﻿using System;
using PhotoHub.BLL.DTO;
using PhotoHub.DAL.Entities;

namespace PhotoHub.BLL.Interfaces
{
    /// <summary>
    /// Interface for getting current user services.
    /// </summary>
    public interface ICurrentUserService : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets current user entity.
        /// </summary>
        User Get { get; }

        /// <summary>
        /// Gets current user data transfer object.
        /// </summary>
        UserDTO GetDTO { get; }

        #endregion
    }
}
