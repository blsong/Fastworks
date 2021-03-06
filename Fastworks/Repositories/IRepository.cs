﻿using Fastworks.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fastworks.Repositories
{
    // 仓储接口
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        #region Methods
        void Add(TAggregateRoot aggregateRoot);

        // 根据聚合根的ID值，从仓储中读取聚合根
        TAggregateRoot GetByKey(Guid key);

        TAggregateRoot GetBySpecification(ISpecification<TAggregateRoot> spec);

        TAggregateRoot GetByExpression(Expression<Func<TAggregateRoot, bool>> expression);

        // 读取所有聚合根。
        IQueryable<TAggregateRoot> GetAll();

        // 以指定的排序字段和排序方式，从仓储中读取所有聚合根。
        IQueryable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Storage.SortOrder sortOrder);

        //  根据指定的规约获取聚合根
        IQueryable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification);

        // 根据指定的规约,以指定的排序字段和排序方式，从仓储中读取聚合根
        IQueryable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Storage.SortOrder sortOrder);

        // 分页支持
        PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Storage.SortOrder sortOrder, int pageNumber, int pageSize);
        PagedResult<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Storage.SortOrder sortOrder, int pageNumber, int pageSize);

        // 返回一个值，该值表示符合指定规约条件的聚合根是否存在。
        bool Exists(ISpecification<TAggregateRoot> specification);

        void Remove(TAggregateRoot aggregateRoot);

        void Update(TAggregateRoot aggregateRoot);

        #endregion
        #region 饥饿加载方式

        IQueryable<TAggregateRoot> GetAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        IQueryable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, 
            Storage.SortOrder sortOrder, 
            params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        IQueryable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, 
            params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        IQueryable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, 
            Expression<Func<TAggregateRoot, dynamic>> sortPredicate, 
            Storage.SortOrder sortOrder, 
            params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        TAggregateRoot GetBySpecification(ISpecification<TAggregateRoot> specification, 
            params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Storage.SortOrder sortOrder, 
            int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        PagedResult<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, 
            Expression<Func<TAggregateRoot, dynamic>> sortPredicate, 
            Storage.SortOrder sortOrder, 
            int pageNumber, 
            int pageSize, 
            params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        #endregion
    }
}
