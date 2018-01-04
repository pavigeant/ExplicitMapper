using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mapper.Rules
{
    public class ListMapRule<TSource, TSourceProperty, TSourceItem, TTarget, TTargetProperty, TTargetItem> : BaseRule<TSource, TTarget, TTargetProperty>
        where TSourceProperty : IEnumerable<TSourceItem>
        where TTargetProperty : IList<TTargetItem>
        where TTargetItem : new()
    {
        private readonly Func<TSource, TSourceProperty> _sourceEnumerable;
        private readonly IMap<TSourceItem, TTargetItem> _childMap;

        public ListMapRule(
            Expression<Func<TTarget, TTargetProperty>> property,
            Func<TSource, TSourceProperty> sourceEnumerable,
            IMap<TSourceItem, TTargetItem> childMap)
            : base(property)
        {
            _sourceEnumerable = sourceEnumerable;
            _childMap = childMap;
        }

        public override void Apply(TSource source, TTarget target)
        {
            var targetList = Property.GetPropertyValue(target);

            foreach (var sourceItem in _sourceEnumerable(source))
            {
                var targetItem = new TTargetItem();
                _childMap.Map(sourceItem, targetItem);
                targetList.Add(targetItem);
            }
        }
    }
}