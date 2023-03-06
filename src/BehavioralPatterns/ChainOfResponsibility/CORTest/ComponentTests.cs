namespace CORTest
{
    public class ComponentTests
    {
        [Fact]
        public void ComponentTest_Test()
        {
            var dialog = new Dialog("预算报告") { WikiUrl = "http://..." };

            var panel = new Panel { ModalHelpText = "本面板用于..." };

            var ok = new Button("确认") { TooltipText = "这是一个确认按钮..." };

            var cancel = new Button("取消");

            dialog.AddChild(panel);
            panel.AddChild(ok);
            panel.AddChild(cancel);

            ok.ShowHelp();     //Component.ShowHelp
            cancel.ShowHelp(); //Component.ShowHelp >> panel.ShowHelp
            panel.ShowHelp();  //panel.ShowHelp
        }
    }
}
