namespace FluentBootstrap
{
    public interface IComponentCreator<TType>
    {
        BootstrapHelper GetHelper();
    }
}