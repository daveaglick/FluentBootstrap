using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using FluentBootstrap.Forms;
using System.Linq.Expressions;
using System.Globalization;

namespace FluentBootstrap
{
    public static class FormExtensions
    {
        // Form

        public static Form<THelper> Form<THelper>(this IFormCreator<THelper> creator, string method = "post")
            where THelper : BootstrapHelper<THelper>
        {
            return new Form<THelper>(creator).SetAction(null).SetMethod(method);
        }

        public static Form<THelper> Form<THelper>(this IFormCreator<THelper> creator, string action, string method = "post")
            where THelper : BootstrapHelper<THelper>
        {
            return new Form<THelper>(creator).SetAction(action).SetMethod(method);
        }

        public static Form<THelper> SetInline<THelper>(this Form<THelper> form, bool inline = true)
            where THelper : BootstrapHelper<THelper>
        {
            return form.ToggleCss(Css.FormInline, inline, Css.FormHorizontal);
        }

        public static Form<THelper> SetHorizontal<THelper>(this Form<THelper> form, int? defaultlabelWidth = null, bool horizontal = true)
            where THelper : BootstrapHelper<THelper>
        {
            form.ToggleCss(Css.FormHorizontal, horizontal, Css.FormInline);
            if (defaultlabelWidth.HasValue)
            {
                form.DefaultLabelWidth = defaultlabelWidth.Value;
            }
            return form;
        }

        // Use action = null to reset form action to current request url
        public static Form<THelper> SetAction<THelper>(this Form<THelper> form, string action)
            where THelper : BootstrapHelper<THelper>
        {
            return form.MergeAttribute("action", action);
        }

        public static Form<THelper> SetMethod<THelper>(this Form<THelper> form, string method)
            where THelper : BootstrapHelper<THelper>
        {
            form.MergeAttribute("method", method);
            return form;
        }

        // FieldSet

        public static FieldSet<THelper> FieldSet<THelper>(this IFieldSetCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new FieldSet<THelper>(creator);
        }

        // FormGroup

        public static FormGroup<THelper> FormGroup<THelper>(this IFormGroupCreator<THelper> creator, string label = null, string labelFor = null)
            where THelper : BootstrapHelper<THelper>
        {
            FormGroup<THelper> formGroup = new FormGroup<THelper>(creator);
            if (label != null)
            {
                formGroup.ControlLabel = formGroup.GetWrapper().ControlLabel(label, labelFor);
            }
            return formGroup;
        }

        public static FormGroup<THelper> SetGroupLabel<THelper, TThis>(this FormGroup<THelper> formGroup, string label, string labelFor = null, Action<ControlLabel<THelper>> labelAction = null)
            where THelper : BootstrapHelper<THelper>
        {
            if (label != null)
            {
                ControlLabel<THelper> controlLabel = new ControlLabel<THelper>(formGroup.Helper, label).For(labelFor);
                formGroup.ControlLabel = formGroup.GetWrapper().ControlLabel(label, labelFor);
                if (labelAction != null)
                {
                    labelAction(controlLabel);
                }
            }
            return formGroup;
        }

        public static FormGroup<THelper> SetHorizontal<THelper>(this FormGroup<THelper> formGroup, bool? horizontal = true)
            where THelper : BootstrapHelper<THelper>
        {
            formGroup.Horizontal = horizontal;
            return formGroup;
        }

        // ControlLabel

        public static ControlLabel<THelper> ControlLabel<THelper>(this IControlLabelCreator<THelper> creator, string text, string labelFor = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new ControlLabel<THelper>(creator, text).For(labelFor);
        }

        public static ControlLabel<THelper> For<THelper>(this ControlLabel<THelper> label, string labelFor)
            where THelper : BootstrapHelper<THelper>
        {
            return label.MergeAttribute("for", labelFor);
        }

        // Hidden

        public static Hidden<THelper> Hidden<THelper>(this IFormControlCreator<THelper> creator, string name = null, object value = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new Hidden<THelper>(creator).SetName(name).SetValue(value);
        }

        public static Hidden<THelper> SetName<THelper>(this Hidden<THelper> hidden, string name)
            where THelper : BootstrapHelper<THelper>
        {
            return hidden.MergeAttribute("name", name == null ? null : hidden.Helper.GetFullHtmlFieldName(name));
        }

        // Input

        public static Input<THelper> Input<THelper>(this IFormControlCreator<THelper> creator, string name = null, string label = null, object value = null, string format = null, FormInputType inputType = FormInputType.Text)
            where THelper : BootstrapHelper<THelper>
        {
            return new Input<THelper>(creator, inputType).SetName(name).SetControlLabel(label).SetValue(value, format);
        }

        public static Input<THelper> SetPlaceholder<THelper>(this Input<THelper> input, string placeholder)
            where THelper : BootstrapHelper<THelper>
        {
            return input.MergeAttribute("placeholder", placeholder);
        }

        public static Input<THelper> SetReadonly<THelper>(this Input<THelper> input, bool toggle = true)
            where THelper : BootstrapHelper<THelper>
        {
            return input.MergeAttribute("readonly", toggle ? string.Empty : null);
        }

        public static Input<THelper> SetFeedback<THelper>(this Input<THelper> input, Icon icon)
            where THelper : BootstrapHelper<THelper>
        {
            if (icon != Icon.None)
            {
                input.ToggleCss(Css.HasFeedback, true);
                input.Icon = icon;
            }
            return input;
        }

        // TextArea

        public static TextArea<THelper> TextArea<THelper>(this IFormControlCreator<THelper> creator, string name = null, string label = null, object value = null, string format = null, int? rows = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new TextArea<THelper>(creator).SetName(name).SetControlLabel(label).SetValue(value, format).SetRows(rows);
        }

        public static TextArea<THelper> SetRows<THelper>(this TextArea<THelper> textArea, int? rows)
            where THelper : BootstrapHelper<THelper>
        {
            return textArea.MergeAttribute("rows", rows == null ? null : rows.Value.ToString());
        }

        public static TextArea<THelper> SetValue<THelper>(this TextArea<THelper> textArea, object value, string format = null)
            where THelper : BootstrapHelper<THelper>
        {
            textArea.TextContent = value == null ? null : textArea.Helper.FormatValue(value, format);
            return textArea;
        }

        public static TextArea<THelper> SetPlaceholder<THelper>(this TextArea<THelper> textArea, string placeholder)
            where THelper : BootstrapHelper<THelper>
        {
            return textArea.MergeAttribute("placeholder", placeholder);
        }

        // CheckedControl

        public static CheckedControl<THelper> CheckBox<THelper>(this IFormControlCreator<THelper> creator, string name = null, string label = null, string description = null, bool isChecked = false)
            where THelper : BootstrapHelper<THelper>
        {
            return new CheckedControl<THelper>(creator, Css.Checkbox).SetName(name).SetControlLabel(label).SetDescription(description).SetChecked(isChecked);
        }

        public static CheckedControl<THelper> Radio<THelper>(this IFormControlCreator<THelper> creator, string name = null, string label = null, string description = null, object value = null, bool isChecked = false)
            where THelper : BootstrapHelper<THelper>
        {
            return new CheckedControl<THelper>(creator, Css.Radio).SetName(name).SetControlLabel(label).SetDescription(description).SetValue(value).SetChecked(isChecked);
        }

        public static CheckedControl<THelper> SetDescription<THelper>(this CheckedControl<THelper> checkedControl, string description)
            where THelper : BootstrapHelper<THelper>
        {
            checkedControl.Description = description;
            return checkedControl;
        }

        public static CheckedControl<THelper> SetInline<THelper>(this CheckedControl<THelper> checkedControl, bool inline = true)
            where THelper : BootstrapHelper<THelper>
        {
            checkedControl.Inline = inline;
            return checkedControl;
        }

        public static CheckedControl<THelper> SetChecked<THelper>(this CheckedControl<THelper> checkedControl, bool @checked = true)
            where THelper : BootstrapHelper<THelper>
        {
            return checkedControl.MergeAttribute("checked", @checked ? "checked" : null);
        }

        // Select

        public static Select<THelper> Select<THelper>(this IFormControlCreator<THelper> creator, string name = null, string label = null, params object[] options)
            where THelper : BootstrapHelper<THelper>
        {
            return new Select<THelper>(creator).SetName(name).SetControlLabel(label).AddOptions(options);
        }

        public static Select<THelper> SetMultiple<THelper>(this Select<THelper> select, bool multiple = true)
            where THelper : BootstrapHelper<THelper>
        {
            return select.MergeAttribute("multiple", multiple ? "multiple" : null);
        }

        public static Select<THelper> AddOptions<THelper>(this Select<THelper> select, params object[] options)
            where THelper : BootstrapHelper<THelper>
        {
            select.Options.Clear();
            foreach (object option in options)
            {
                select.AddOption(option);
            }
            return select;
        }

        public static Select<THelper> AddOption<THelper>(this Select<THelper> select, object option, string format = null)
            where THelper : BootstrapHelper<THelper>
        {
            if (option != null)
            {
                select.Options.Add(select.Helper.FormatValue(option, format));
            }
            return select;
        }

        // Static

        public static Static<THelper> Static<THelper>(this IFormControlCreator<THelper> creator, string label = null, object value = null, string format = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new Static<THelper>(creator).SetControlLabel(label).SetValue(value, format);
        }

        public static Static<THelper> SetValue<THelper>(this Static<THelper> st, object value, string format = null)
            where THelper : BootstrapHelper<THelper>
        {
            st.TextContent = value == null ? null : st.Helper.FormatValue(value, format);
            return st;
        }

        // Buttons

        public static InputButton<THelper> InputButton<THelper>(this IFormControlCreator<THelper> creator, ButtonType buttonType = ButtonType.Button, string text = null, string label = null, object value = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new InputButton<THelper>(creator, buttonType).SetText(text).SetControlLabel(label).SetValue(value);
        }

        public static FormButton<THelper> FormButton<THelper>(this IFormControlCreator<THelper> creator, ButtonType buttonType = ButtonType.Button, string text = null, string label = null, object value = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new FormButton<THelper>(creator, buttonType).SetText(text).SetControlLabel(label).SetValue(value);
        }

        public static FormButton<THelper> Submit<THelper>(this IFormControlCreator<THelper> creator, string text = "Submit", string label = null, object value = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new FormButton<THelper>(creator, ButtonType.Submit).SetText(text).SetControlLabel(label).SetValue(value).SetState(ButtonState.Primary);
        }

        public static FormButton<THelper> Reset<THelper>(this IFormControlCreator<THelper> creator, string text = "Reset", string label = null, object value = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new FormButton<THelper>(creator, ButtonType.Reset).SetText(text).SetControlLabel(label).SetValue(value);
        }
        
        // FormControl (instance)

        public static FormControl<THelper> FormControl<THelper>(this IFormControlCreator<THelper> creator, string label = null, string labelFor = null)
            where THelper : BootstrapHelper<THelper>
        {
            FormControl<THelper> formControl = new FormControl<THelper>(creator);
            formControl.Label = new ControlLabel<THelper>(formControl.Helper, label).For(labelFor);
            return formControl;
        }

        public static FormControl<THelper> AddStaticClass<THelper>(this FormControl<THelper> formControl, bool addStaticClass = true)
            where THelper : BootstrapHelper<THelper>
        {
            formControl.ToggleCss(Css.FormControlStatic, addStaticClass);
            return formControl;
        }

        // Help

        public static HelpBlock<THelper> HelpBlock<THelper>(this IFormControlCreator<THelper> creator, string text = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new HelpBlock<THelper>(creator).SetText(text);
        }

        // FormControl

        public static TThis SetControlLabel<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string label, Action<ControlLabel<THelper>> labelAction = null)
            where THelper : BootstrapHelper<THelper>
            where TThis : FormControl<THelper, TThis, TWrapper>
            where TWrapper : FormControlWrapper<THelper>, new()
        {
            TThis control = component.GetThis();
            if (label != null)
            {
                ControlLabel<THelper> controlLabel = new ControlLabel<THelper>(control.Helper, label).For(control.GetName());
                control.Label = controlLabel;
                if (labelAction != null)
                {
                    labelAction(controlLabel);
                }
            }
            else
            {
                control.Label = null;
            }
            return control;
        }

        public static TThis SetHelp<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string help)
            where THelper : BootstrapHelper<THelper>
            where TThis : FormControl<THelper, TThis, TWrapper>
            where TWrapper : FormControlWrapper<THelper>, new()
        {
            TThis control = component.GetThis();
            control.Help = help;
            return control;
        }

        public static TThis EnsureFormGroup<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool ensureFormGroup = true)
            where THelper : BootstrapHelper<THelper>
            where TThis : FormControl<THelper, TThis, TWrapper>
            where TWrapper : FormControlWrapper<THelper>, new()
        {
            TThis control = component.GetThis();
            control.EnsureFormGroup = ensureFormGroup;
            return control;
        }

        public static TThis SetSize<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, InputSize size)
            where THelper : BootstrapHelper<THelper>
            where TThis : FormControl<THelper, TThis, TWrapper>
            where TWrapper : FormControlWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(size);
        }

        // IFormValidation

        public static TThis SetState<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, ValidationState state)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IFormValidation
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(state);
        }

        // InputGroup

        public static InputGroup<THelper> InputGroup<THelper>(this IInputGroupCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new InputGroup<THelper>(creator);
        }

        public static InputGroup<THelper> SetSize<THelper>(this InputGroup<THelper> inputGroup, InputGroupSize size)
            where THelper : BootstrapHelper<THelper>
        {
            return inputGroup.ToggleCss(size);
        }

        public static InputGroupAddon<THelper> InputGroupAddon<THelper>(this IInputGroupAddonCreator<THelper> creator, object content = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new InputGroupAddon<THelper>(creator).AddContent(content);
        }

        public static InputGroupButton<THelper> InputGroupButton<THelper>(this IInputGroupButtonCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new InputGroupButton<THelper>(creator);
        }

        // Use special creator extensions to create input group addons so we can control the output more closely (I.e., no labels, form groups, etc.)

        public static Input<THelper> Input<THelper>(this InputGroupWrapper<THelper> inputGroup, string name = null, object value = null, string format = null, FormInputType inputType = FormInputType.Text)
            where THelper : BootstrapHelper<THelper>
        {
            return new Input<THelper>(inputGroup, inputType).SetName(name).SetValue(value, format).EnsureFormGroup(false);
        }

        public static CheckedControl<THelper> CheckBox<THelper>(this InputGroupAddonWrapper<THelper> inputGroupAddon, string name = null, bool isChecked = false)
            where THelper : BootstrapHelper<THelper>
        {
            return new CheckedControl<THelper>(inputGroupAddon, Css.Checkbox) { SuppressLabelWrapper = true }
                .SetName(name).SetChecked(isChecked).EnsureFormGroup(false).SetInline(true);
        }

        public static CheckedControl<THelper> Radio<THelper>(this InputGroupAddonWrapper<THelper> inputGroupAddon, string name = null, object value = null, bool isChecked = false)
            where THelper : BootstrapHelper<THelper>
        {
            return new CheckedControl<THelper>(inputGroupAddon, Css.Radio) { SuppressLabelWrapper = true }
                .SetName(name).SetValue(value).SetChecked(isChecked).EnsureFormGroup(false).SetInline(true);
        }
    }
}
