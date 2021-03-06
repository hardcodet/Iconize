﻿using System;
using System.ComponentModel;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.iOS;
using Plugin.Iconize.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconButton), typeof(IconButtonRenderer))]

namespace FormsPlugin.Iconize.iOS
{
    /// <summary>
    /// Defines the <see cref="IconButtonRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.ButtonRenderer" />
    public class IconButtonRenderer : ButtonRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="ElementChangedEventArgs{Button}" /> instance containing the event data.
        /// </param>
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            UpdateText();
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="PropertyChangedEventArgs" /> instance containing the event data.
        /// </param>
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            switch (e.PropertyName)
            {
                case nameof(IconButton.FontSize):
                case nameof(IconButton.Text):
                case nameof(IconButton.TextColor):
                    UpdateText();
                    break;
            }
        }

        /// <summary>
        /// Updates the text.
        /// </summary>
        private void UpdateText()
        {
            var icon = Plugin.Iconize.Iconize.FindIconForKey(Element.Text);
            if (icon != null)
            {
                var font = Plugin.Iconize.Iconize.FindModuleOf(icon)?.ToUIFont((nfloat)Element.FontSize);
                if (font != null)
                {
                    Control.SetTitle($"{icon.Character}", UIControlState.Normal);
                    Control.Font = font;
                }
            }
        }
    }
}