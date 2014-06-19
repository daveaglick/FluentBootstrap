namespace FluentBootstrap
{
    public interface IComponentCreator<TModel>
    {
        BootstrapHelper<TModel> GetHelper();
    }
}