using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using FluentBootstrap.Forms;
using System.Linq.Expressions;
using System.Globalization;
using FluentBootstrap.Internals;

namespace FluentBootstrap
{
    public static class FormExtensions
    {
        // Form

        public static ComponentBuilder<TConfig, Form> Form<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string method = "post")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Form>
        {
            return new ComponentBuilder<TConfig, Form>(helper.Config, new Form(helper))
                .SetAction(null)
                .SetMethod(method);
        }

        public static ComponentBuilder<TConfig, Form> Form<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string action, string method = "post")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Form>
        {
            return new ComponentBuilder<TConfig, Form>(helper.Config, new Form(helper))
                .SetAction(action)
                .SetMethod(method);
        }

        public static ComponentBuilder<TConfig, Form> SetInline<TConfig>(this ComponentBuilder<TConfig, Form> builder, bool inline = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.FormInline, inline, Css.FormHorizontal);
            return builder;
        }

        public static ComponentBuilder<TConfig, Form> SetHorizontal<TConfig>(this ComponentBuilder<TConfig, Form> builder, int? defaultlabelWidth = null, bool horizontal = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.FormHorizontal, horizontal, Css.FormInline);
            if (defaultlabelWidth.HasValue)
            {
                builder.Component.DefaultLabelWidth = defaultlabelWidth.Value;
            }
            return builder;
        }

        // Use action = null to reset form action to current request url
        public static ComponentBuilder<TConfig, Form> SetAction<TConfig>(this ComponentBuilder<TConfig, Form> builder, string action)
            where TConfig : BootstrapConfig
        {
            builder.Component.MergeAttribute("action", action);
            return builder;
        }

        public static ComponentBuilder<TConfig, Form> SetMethod<TConfig>(this ComponentBuilder<TConfig, Form> builder, string method)
            where TConfig : BootstrapConfig
        {
            builder.Component.MergeAttribute("method", method);
            return builder;
        }

        // FieldSet

        public static ComponentBuilder<TConfig, FieldSet> FieldSet<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<FieldSet>
        {
            return new ComponentBuilder<TConfig, FieldSet>(helper.Config, new FieldSet(helper));
        }

        // FormGroup

        public static ComponentBuilder<TConfig, FormGroup> FormGroup<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string label = null, string labelFor = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<FormGroup>
        {
            ComponentBuilder<TConfig, FormGroup> builder = new ComponentBuilder<TConfig, FormGroup>(helper.Config, new FormGroup(helper));
            if (label != null)
            {
                builder.Component.ControlLabel = builder.GetHelper().ControlLabel(label, labelFor).Component;
            }
            return builder;
        }

        public static ComponentBuilder<TConfig, FormGroup> SetGroupLabel<TConfig>(this ComponentBuilder<TConfig, FormGroup> builder, string label, string labelFor = null, Action<ComponentBuilder<TConfig, ControlLabel>> labelAction = null)
            where TConfig : BootstrapConfig
        {
            if (label != null)
            {
                ComponentBuilder<TConfig, ControlLabel> controlLabelBuilder = builder.GetHelper().ControlLabel(label, labelFor);
                if (labelAction != null)
                {
                    labelAction(controlLabelBuilder);
                }
                builder.Component.ControlLabel = controlLabelBuilder.Component;
            }
            return builder;
        }

        public static ComponentBuilder<TConfig, FormGroup> SetHorizontal<TConfig>(this ComponentBuilder<TConfig, FormGroup> builder, bool horizontal = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Horizontal = horizontal;
            return builder;
        }

        public static ComponentBuilder<TConfig, FormGroup> SetAutoColumns<TConfig>(this ComponentBuilder<TConfig, FormGroup> builder, bool autoColumns = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.AutoColumns = autoColumns;
            return builder;
        }        

        public static ComponentBuilder<TConfig, FormGroup> SetFeedback<TConfig>(this ComponentBuilder<TConfig, FormGroup> builder, Icon icon)
            where TConfig : BootstrapConfig
        {
            if (icon != Icon.None)
            {
                builder.Component.ToggleCss(Css.HasFeedback, true);
                builder.Component.Icon = icon;
            }
            return builder;
        }

        // ControlLabel

        public static ComponentBuilder<TConfig, ControlLabel> ControlLabel<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text, string labelFor = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<ControlLabel>
        {
            return new ComponentBuilder<TConfig, ControlLabel>(helper.Config, new ControlLabel(helper, text))
                .For(labelFor);
        }

        public static ComponentBuilder<TConfig, ControlLabel> For<TConfig>(this ComponentBuilder<TConfig, ControlLabel> builder, string labelFor)
            where TConfig : BootstrapConfig
        {
            builder.Component.MergeAttribute("for", labelFor);
            return builder;
        }

        // Hidden

        public static ComponentBuilder<TConfig, Hidden> Hidden<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string name = null, object value = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Hidden>
        {
            return new ComponentBuilder<TConfig, Hidden>(helper.Config, new Hidden(helper))
                .SetName(name)
                .SetValue(value);
        }

        public static ComponentBuilder<TConfig, Hidden> SetName<TConfig>(this ComponentBuilder<TConfig, Hidden> builder, string name)
            where TConfig : BootstrapConfig
        {
            builder.Component.MergeAttribute("name", name == null ? null : builder.Config.GetFullHtmlFieldName(name));
            return builder;
        }

        // Input

        public static ComponentBuilder<TConfig, Input> Input<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string name = null, string label = null, object value = null, string valueFormat = null, FormInputType inputType = FormInputType.Text)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Input>
        {
            return new ComponentBuilder<TConfig, Input>(helper.Config, new Input(helper, inputType))
                .SetName(name)
                .SetControlLabel(label)
                .SetValue(value, valueFormat);
        }

        public static ComponentBuilder<TConfig, Input> SetPlaceholder<TConfig>(this ComponentBuilder<TConfig, Input> builder, string placeholder)
            where TConfig : BootstrapConfig
        {
            builder.Component.MergeAttribute("placeholder", placeholder);
            return builder;
        }

        public static ComponentBuilder<TConfig, Input> SetReadonly<TConfig>(this ComponentBuilder<TConfig, Input> builder, bool toggle = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.MergeAttribute("readonly", toggle ? string.Empty : null);
            return builder;
        }

        public static ComponentBuilder<TConfig, Input> SetFeedback<TConfig>(this ComponentBuilder<TConfig, Input> builder, Icon icon)
            where TConfig : BootstrapConfig
        {
            if (icon != Icon.None)
            {
                builder.Component.ToggleCss(Css.HasFeedback, true);
                builder.Component.Icon = icon;
            }
            return builder;
        }

        // TextArea

        public static ComponentBuilder<TConfig, TextArea> TextArea<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string name = null, string label = null, object value = null, string valueFormat = null, int? rows = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<TextArea>
        {
            return new ComponentBuilder<TConfig, TextArea>(helper.Config, new TextArea(helper))
                .SetName(name)
                .SetControlLabel(label)
                .SetValue(value, valueFormat)
                .SetRows(rows);
        }

        public static ComponentBuilder<TConfig, TextArea> SetRows<TConfig>(this ComponentBuilder<TConfig, TextArea> builder, int? rows)
            where TConfig : BootstrapConfig
        {
            builder.Component.MergeAttribute("rows", rows == null ? null : rows.Value.ToString());
            return builder;
        }

        public static ComponentBuilder<TConfig, TextArea> SetValue<TConfig>(this ComponentBuilder<TConfig, TextArea> builder, object value, string format = null)
            where TConfig : BootstrapConfig
        {
            builder.Component.TextContent = value == null ? null : builder.Config.FormatValue(value, format);
            return builder;
        }

        public static ComponentBuilder<TConfig, TextArea> SetPlaceholder<TConfig>(this ComponentBuilder<TConfig, TextArea> builder, string placeholder)
            where TConfig : BootstrapConfig
        {
            builder.Component.MergeAttribute("placeholder", placeholder);
            return builder;
        }

        // CheckedControl

        public static ComponentBuilder<TConfig, CheckedControl> CheckBox<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string name = null, string label = null, string description = null, bool isChecked = false)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<CheckedControl>
        {
            return new ComponentBuilder<TConfig, CheckedControl>(helper.Config, new CheckedControl(helper, Css.Checkbox))
                .SetName(name)
                .SetControlLabel(label)
                .SetDescription(description)
                .SetChecked(isChecked);
        }

        public static ComponentBuilder<TConfig, CheckedControl> Radio<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string name = null, string label = null, string description = null, object value = null, bool isChecked = false)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<CheckedControl>
        {
            return new ComponentBuilder<TConfig, CheckedControl>(helper.Config, new CheckedControl(helper, Css.Radio))
                .SetName(name)
                .SetControlLabel(label)
                .SetDescription(description)
                .SetValue(value)
                .SetChecked(isChecked);
        }

        public static ComponentBuilder<TConfig, CheckedControl> SetDescription<TConfig>(this ComponentBuilder<TConfig, CheckedControl> builder, string description)
            where TConfig : BootstrapConfig
        {
            builder.Component.Description = description;
            return builder;
        }

        public static ComponentBuilder<TConfig, CheckedControl> SetInline<TConfig>(this ComponentBuilder<TConfig, CheckedControl> builder, bool inline = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Inline = inline;
            return builder;
        }

        public static ComponentBuilder<TConfig, CheckedControl> SetChecked<TConfig>(this ComponentBuilder<TConfig, CheckedControl> builder, bool isChecked = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Checked = isChecked;
            return builder;
        }

        // Select

        public static ComponentBuilder<TConfig, Select> Select<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string name = null, string label = null, params string[] options)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Select>
        {
            return new ComponentBuilder<TConfig, Select>(helper.Config, new Select(helper))
                .SetName(name)
                .SetControlLabel(label)
                .AddOptions(options);
        }

        public static ComponentBuilder<TConfig, Select> Select<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string name, string label, IEnumerable<KeyValuePair<string, string>> options)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Select>
        {
            return new ComponentBuilder<TConfig, Select>(helper.Config, new Select(helper))
                .SetName(name)
                .SetControlLabel(label)
                .AddOptions(options);
        }

        public static ComponentBuilder<TConfig, Select> SetMultiple<TConfig>(this ComponentBuilder<TConfig, Select> builder, bool multiple = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Multiple = multiple;
            return builder;
        }

        public static ComponentBuilder<TConfig, Select> AddOptions<TConfig>(this ComponentBuilder<TConfig, Select> builder, params string[] options)
            where TConfig : BootstrapConfig
        {
            foreach (string option in options)
            {
                builder.AddChild(x => x.SelectOption(option));
            }
            return builder;
        }

        public static ComponentBuilder<TConfig, Select> AddOptions<TConfig>(this ComponentBuilder<TConfig, Select> builder, IEnumerable<KeyValuePair<string, string>> options)
            where TConfig : BootstrapConfig
        {
            foreach (KeyValuePair<string, string> option in options)
            {
                builder.AddChild(x => x.SelectOption(option.Key, option.Value));
            }
            return builder;
        }

        public static ComponentBuilder<TConfig, Select> AddOption<TConfig>(this ComponentBuilder<TConfig, Select> builder, string text, string value = null, bool selected = false)
            where TConfig : BootstrapConfig
        {
            builder.AddChild(x => x.SelectOption(text, value, selected));
            return builder;
        }

        public static ComponentBuilder<TConfig, SelectOption> SelectOption<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text, string value = null, bool selected = false)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<SelectOption>
        {
            return new ComponentBuilder<TConfig, SelectOption>(helper.Config, new SelectOption(helper))
                .SetText(text)
                .SetValue(value)
                .SetSelected(selected);
        }

        public static ComponentBuilder<TConfig, SelectOption> SetValue<TConfig>(this ComponentBuilder<TConfig, SelectOption> builder, string value)
            where TConfig : BootstrapConfig
        {
            builder.Component.Value = value;
            return builder;
        }

        public static ComponentBuilder<TConfig, SelectOption> SetSelected<TConfig>(this ComponentBuilder<TConfig, SelectOption> builder, bool selected = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Selected = selected;
            return builder;
        }

        // Static

        public static ComponentBuilder<TConfig, Static> Static<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string label = null, object value = null, string valueFormat = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Static>
        {
            return new ComponentBuilder<TConfig, Static>(helper.Config, new Static(helper))
                .SetControlLabel(label)
                .SetValue(value, valueFormat);
        }

        public static ComponentBuilder<TConfig, Static> SetValue<TConfig>(this ComponentBuilder<TConfig, Static> builder, object value, string format = null)
            where TConfig : BootstrapConfig
        {
            builder.Component.TextContent = value == null ? null : builder.Config.FormatValue(value, format);
            return builder;
        }

        // Buttons

        public static ComponentBuilder<TConfig, InputButton> InputButton<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string value = null, string label = null, ButtonType buttonType = ButtonType.Button)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<InputButton>
        {
            return new ComponentBuilder<TConfig, InputButton>(helper.Config, new InputButton(helper, buttonType))
                .SetValue(value)
                .SetControlLabel(label);
        }

        public static ComponentBuilder<TConfig, FormButton> FormButton<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null, string label = null, object value = null, ButtonType buttonType = ButtonType.Button)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<FormButton>
        {
            return new ComponentBuilder<TConfig, FormButton>(helper.Config, new FormButton(helper, buttonType))
                .SetText(text)
                .SetControlLabel(label)
                .SetValue(value);
        }

        public static ComponentBuilder<TConfig, FormButton> Submit<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = "Submit", string label = null, object value = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<FormButton>
        {
            return new ComponentBuilder<TConfig, FormButton>(helper.Config, new FormButton(helper, ButtonType.Submit))
                .SetText(text)
                .SetControlLabel(label)
                .SetValue(value)
                .SetState(ButtonState.Primary);
        }

        public static ComponentBuilder<TConfig, FormButton> Reset<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = "Reset", string label = null, object value = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<FormButton>
        {
            return new ComponentBuilder<TConfig, FormButton>(helper.Config, new FormButton(helper, ButtonType.Reset))
                .SetText(text)
                .SetControlLabel(label)
                .SetValue(value);
        }

        // FormControl (instance)

        public static ComponentBuilder<TConfig, FormControl> FormControl<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string label = null, string labelFor = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<FormControl>
        {
            ComponentBuilder<TConfig, FormControl> builder = new ComponentBuilder<TConfig, FormControl>(helper.Config, new FormControl(helper));
            builder.Component.Label = builder.GetHelper().ControlLabel(label).For(labelFor).Component;
            return builder;
        }

        public static ComponentBuilder<TConfig, FormControl> AddStaticClass<TConfig>(this ComponentBuilder<TConfig, FormControl> builder, bool addStaticClass = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.FormControlStatic, addStaticClass);
            return builder;
        }

        // Help

        public static ComponentBuilder<TConfig, HelpBlock> HelpBlock<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<HelpBlock>
        {
            return new ComponentBuilder<TConfig, HelpBlock>(helper.Config, new HelpBlock(helper)).SetText(text);
        }

        // FormControl

        public static ComponentBuilder<TConfig, TFormControl> SetControlLabel<TConfig, TFormControl>(this ComponentBuilder<TConfig, TFormControl> builder, string label, Action<ComponentBuilder<TConfig, ControlLabel>> labelAction = null)
            where TConfig : BootstrapConfig
            where TFormControl : FormControl
        {
            if (label != null)
            {
                ComponentBuilder<TConfig, ControlLabel> controlLabelBuilder = builder.GetHelper().ControlLabel(label).For(builder.Component.GetAttribute("name"));
                if (labelAction != null)
                {
                    labelAction(controlLabelBuilder);
                }
                builder.Component.Label = controlLabelBuilder.Component;
            }
            else
            {
                builder.Component.Label = null;
            }
            return builder;
        }

        public static ComponentBuilder<TConfig, TFormControl> SetHelp<TConfig, TFormControl>(this ComponentBuilder<TConfig, TFormControl> builder, string help)
            where TConfig : BootstrapConfig
            where TFormControl : FormControl
        {
            builder.Component.Help = help;
            return builder;
        }

        public static ComponentBuilder<TConfig, TFormControl> EnsureFormGroup<TConfig, TFormControl>(this ComponentBuilder<TConfig, TFormControl> builder, bool ensureFormGroup = true)
            where TConfig : BootstrapConfig
            where TFormControl : FormControl
        {
            builder.Component.EnsureFormGroup = ensureFormGroup;
            return builder;
        }

        public static ComponentBuilder<TConfig, TFormControl> SetSize<TConfig, TFormControl>(this ComponentBuilder<TConfig, TFormControl> builder, InputSize size)
            where TConfig : BootstrapConfig
            where TFormControl : FormControl
        {
            builder.Component.ToggleCss(size);
            return builder;
        }

        // IFormValidation

        public static ComponentBuilder<TConfig, TTag> SetState<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, ValidationState state)
            where TConfig : BootstrapConfig
            where TTag : Tag, IFormValidation
        {
            builder.Component.ToggleCss(state);
            return builder;
        }

        // InputGroup

        public static ComponentBuilder<TConfig, InputGroup> InputGroup<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<InputGroup>
        {
            return new ComponentBuilder<TConfig, InputGroup>(helper.Config, new InputGroup(helper));
        }

        public static ComponentBuilder<TConfig, InputGroup> SetSize<TConfig>(this ComponentBuilder<TConfig, InputGroup> builder, InputGroupSize size)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(size);
            return builder;
        }

        public static ComponentBuilder<TConfig, InputGroupAddon> InputGroupAddon<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, object content = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<InputGroupAddon>
        {
            return new ComponentBuilder<TConfig, InputGroupAddon>(helper.Config, new InputGroupAddon(helper))
                .AddContent(content);
        }

        public static ComponentBuilder<TConfig, InputGroupButton> InputGroupButton<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<InputGroupButton>
        {
            return new ComponentBuilder<TConfig, InputGroupButton>(helper.Config, new InputGroupButton(helper));
        }

        // Use special creator extensions to create input group addons so we can control the output more closely (I.e., no labels, form groups, etc.)

        public static ComponentBuilder<TConfig, Input> Input<TConfig>(this ComponentWrapper<TConfig, InputGroup> wrapper, string name = null, object value = null, string valueFormat = null, FormInputType inputType = FormInputType.Text)
            where TConfig : BootstrapConfig
        {

            return new ComponentBuilder<TConfig, Input>(wrapper.Config, new Input(wrapper, inputType))
                .SetName(name)
                .SetValue(value, valueFormat)
                .EnsureFormGroup(false);
        }

        public static ComponentBuilder<TConfig, CheckedControl> CheckBox<TConfig>(this ComponentWrapper<TConfig, InputGroupAddon> wrapper, string name = null, bool isChecked = false)
            where TConfig : BootstrapConfig
        {
            return new ComponentBuilder<TConfig, CheckedControl>(wrapper.Config, new CheckedControl(wrapper, Css.Checkbox) { SuppressLabelWrapper = true })
                .SetName(name)
                .SetChecked(isChecked)
                .EnsureFormGroup(false)
                .SetInline(true);
        }

        public static ComponentBuilder<TConfig, CheckedControl> Radio<TConfig>(this ComponentWrapper<TConfig, InputGroupAddon> wrapper, string name = null, object value = null, bool isChecked = false)
            where TConfig : BootstrapConfig
        {
            return new ComponentBuilder<TConfig, CheckedControl>(wrapper.Config, new CheckedControl(wrapper, Css.Radio) { SuppressLabelWrapper = true })
                .SetName(name)
                .SetValue(value)
                .SetChecked(isChecked)
                .EnsureFormGroup(false)
                .SetInline(true);
        }
    }
}
