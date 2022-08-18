﻿using Microsoft.AspNetCore.Components;
using System;

namespace Jimmys20.BlazorComponents
{
    public class JmGridLayoutRow<T> : ComponentBase, IDisposable
    {
        /// <summary>
        /// Specifies the row's height.
        /// </summary>
        [Parameter] public string Height { get; set; } = "none";

        [CascadingParameter]
        public JmGridLayout<T> GridLayout { get; set; }

        protected override void OnInitialized()
        {
            GridLayout.AddRow(this);
        }

        public void Dispose()
        {
            GridLayout.RemoveRow(this);
        }
    }
}