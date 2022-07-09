using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Counter.Data
{
    /// <summary>
    /// Tracks the counting progress
    /// </summary>
    internal class ValueTracker : DependencyObject
    {
        #region Value

        /// <summary>
        /// Value Dependency Property
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(ValueTracker),
                new FrameworkPropertyMetadata((int)0,
                    new PropertyChangedCallback(OnValueChanged)));

        /// <summary>
        /// The counter's current value
        /// </summary>
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Handles changes to the Value property.
        /// </summary>
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ValueTracker target = (ValueTracker)d;
            int oldValue = (int)e.OldValue;
            int newValue = target.Value;
            target.OnValueChanged(oldValue, newValue);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the Value property.
        /// </summary>
        protected virtual void OnValueChanged(int oldValue, int newValue)
        {
            if (oldValue != newValue)
                UpdateButtonCanProgress();
        }

        #endregion

        #region Target

        /// <summary>
        /// Target Dependency Property
        /// </summary>
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(int), typeof(ValueTracker),
                new FrameworkPropertyMetadata((int)100,
                    new PropertyChangedCallback(OnTargetChanged)));

        /// <summary>
        /// The counter's target value.
        /// </summary>
        public int Target
        {
            get { return (int)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        /// <summary>
        /// Handles changes to the Target property.
        /// </summary>
        private static void OnTargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ValueTracker target = (ValueTracker)d;
            int oldTarget = (int)e.OldValue;
            int newTarget = target.Target;
            target.OnTargetChanged(oldTarget, newTarget);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the Target property.
        /// </summary>
        protected virtual void OnTargetChanged(int oldTarget, int newTarget)
        {
            if (oldTarget != newTarget)
                UpdateButtonCanProgress();
        }

        #endregion

        #region CanProgress

        /// <summary>
        /// CanProgress Dependency Property
        /// </summary>
        public static readonly DependencyProperty CanProgressProperty =
            DependencyProperty.Register("CanProgress", typeof(bool), typeof(ValueTracker),
                new FrameworkPropertyMetadata((bool)true));

        /// <summary>
        /// Indicates whether the Another button should be enabled
        /// </summary>
        public bool CanProgress
        {
            get { return (bool)GetValue(CanProgressProperty); }
            set { SetValue(CanProgressProperty, value); }
        }

        #endregion

        /// <summary>
        /// Creates a ValueTracker
        /// </summary>
        public ValueTracker()
        {

        }

        /// <summary>
        /// Updates the value stored in CanProgress
        /// </summary>
        private void UpdateButtonCanProgress()
        {
            CanProgress = Value < Target;
        }
    }
}
