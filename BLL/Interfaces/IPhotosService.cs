﻿#region using System
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion
using PhotoHub.BLL.DTO;

namespace PhotoHub.BLL.Interfaces
{
    public interface IPhotosService : IDisposable, IReturnUser
    {
        List<FilterDTO> Filters { get; }
        List<ApertureDTO> Apertures { get; }
        List<ExposureDTO> Exposures { get; }
        List<IsoDTO> Isos { get; }
        List<TagDTO> Tags { get; }

        IEnumerable<PhotoDTO> GetAll(int page, int pageSize);

        PhotoDTO Get(int id);
        Task<PhotoDTO> GetAsync(int id);

        IEnumerable<PhotoDTO> GetPhotosHome(int page, int pageSize);

        IEnumerable<PhotoDTO> GetForUser(int page, string userName, int pageSize);

        IEnumerable<PhotoDTO> GetBookmarks(int page, int pageSize);

        IEnumerable<PhotoDTO> GetTags(int tagId, int page, int pageSize);

        IEnumerable<PhotoDTO> Search(int page, string search, int pageSize, int iso, int exposure, int aperture, double focalLength);

        void Bookmark(int id);
        Task BookmarkAsync(int id);

        void DismissBookmark(int id);
        Task DismissBookmarkAsync(int id);

        int Create(string filter, string description, string path, string manufacturer, string model, string iso, string exposure, string aperture, double focalLength, string tags);
        ValueTask<int> CreateAsync(string filter, string description, string path, string manufacturer, string model, string iso, string exposure, string aperture, double focalLength, string tags);

        void Edit(int id, string filter, string description, string iso, string exposure, string aperture, double focalLength, string tags);
        Task EditAsync(int id, string filter, string description, string iso, string exposure, string aperture, double focalLength, string tags);

        void Delete(int id);
        Task DeleteAsync(int id);
    }
}
