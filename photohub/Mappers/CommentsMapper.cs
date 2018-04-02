﻿using System.Collections.Generic;
#region using PhotoHub.BLL
using PhotoHub.BLL.DTO;
using PhotoHub.BLL.Interfaces;
#endregion
using PhotoHub.WEB.ViewModels;

namespace PhotoHub.WEB.Mappers
{
    public class CommentsMapper : IMapper<CommentViewModel, CommentDTO>
    {
        private readonly UsersMapper _usersMapper;

        public CommentsMapper() => _usersMapper = new UsersMapper();

        public CommentViewModel Map(CommentDTO item)
        {
            if (item == null)
                return null;

            return new CommentViewModel()
            {
                Id = item.Id,
                Text = item.Text,
                Date = item.Date.ToString("MMMM dd, yyyy"),
                Owner = _usersMapper.Map(item.Owner)
            };
        }

        public List<CommentViewModel> MapRange(IEnumerable<CommentDTO> items)
        {
            if (items == null)
                return null;

            List<CommentViewModel> comments = new List<CommentViewModel>();
            foreach (CommentDTO item in items)
            {
                comments.Add(new CommentViewModel()
                {
                    Id = item.Id,
                    Text = item.Text,
                    Date = item.Date.ToString("MMMM dd, yyyy"),
                    Owner = _usersMapper.Map(item.Owner)
                });
            }

            return comments;
        }
    }
}