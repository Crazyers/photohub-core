﻿using System.Collections.Generic;
using PhotoHub.DAL.Entities;
using PhotoHub.BLL.DTO;

namespace PhotoHub.BLL.Mappers
{
    /// <summary>
    /// Methods for mapping filter entities to filter data transfer objects.
    /// </summary>
    public static class FiltersMapper
    {
        #region Logic

        /// <summary>
        /// Maps filter entity to filter DTO.
        /// </summary>
        public static FilterDTO Map(Filter item)
        {
            if (item == null)
            {
                return null;
            }

            return new FilterDTO
            {
                Id = item.Id,
                Name = item.Name
            };
        }

        /// <summary>
        /// Maps filter entities to filter DTOs.
        /// </summary>
        public static List<FilterDTO> MapRange(IEnumerable<Filter> items)
        {
            if (items == null)
            {
                return null;
            }

            var filters = new List<FilterDTO>();

            foreach (var filter in items)
            {
                filters.Add(new FilterDTO
                {
                    Id = filter.Id,
                    Name = filter.Name
                });
            }

            return filters;
        }

        #endregion
    }
}
