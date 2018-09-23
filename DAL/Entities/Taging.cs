﻿namespace PhotoHub.DAL.Entities
{
    /// <summary>
    /// Taging entity.
    /// Contains <see cref="PhotoId"/> and <see cref="TagId"/>.
    /// </summary>
    public class Taging : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets and sets photo entity by foreign key.
        /// </summary>
        public Photo Photo { get; set; }

        /// <summary>
        /// Gets and sets foreign key to photo by id.
        /// </summary>
        public int PhotoId { get; set; }

        /// <summary>
        /// Gets and sets tag entity by foreign key.
        /// </summary>
        public Tag Tag { get; set; }

        /// <summary>
        /// Gets and sets foreign key to tag by id.
        /// </summary>
        public int TagId { get; set; }

        #endregion
    }
}
