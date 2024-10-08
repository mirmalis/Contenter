﻿using System.Linq.Expressions;
using Contenter.Models.Contents;
namespace Contenter.Brokers.Contents;

public interface IContentBroker
{
  Task<bool> ChangeMainPageListingStatus(Guid id, bool status);

  Task<List<T>> GetLatestContentsSelection<T>(Expression<Func<Content, T>> expression, int max = 100, int skip = 0);
  Task<T?> GetContentsByIdSelection<T>(Expression<Func<Content, T>> expression, Guid id);

  Task<bool> Shown_at_MainPage(Guid contentId, bool state);
}
