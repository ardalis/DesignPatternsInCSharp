namespace DesignPatternsInCSharp.TemplateMethod
{
    public abstract class PanBakingServiceBase<T> where T:BakedPanFood, new()
    {
        protected T _item;

        // The Template Method
        public T Prepare()
        {
            _item = new T();

            PrepareCrust();

            AddToppings();

            Cover();

            Bake();

            Slice();

            return _item;
        }

        protected abstract void PrepareCrust();

        protected abstract void AddToppings();

        protected abstract void Bake();

        protected abstract void Slice();

        protected virtual void Cover()
        {
            // does nothing by default
        }
    }
}
