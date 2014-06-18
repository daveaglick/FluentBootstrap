namespace FluentBootstrap
{
    public interface ICreateComponent<TModel>
    {
        BootstrapHelper<TModel> GetHelper();
    }
}