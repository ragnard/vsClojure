﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Text;

namespace Microsoft.ClojureExtension.Editor.Parsing
{
	public class TextChangeAdapter
	{
		private readonly BufferTextChangeHandler _bufferTextChangeHandler;

		public TextChangeAdapter(BufferTextChangeHandler bufferTextChangeHandler)
		{
			_bufferTextChangeHandler = bufferTextChangeHandler;
		}

		public void OnTextChange(object sender, TextContentChangedEventArgs args)
		{
			List<TextChangeData> changeData = new List<TextChangeData>();
			foreach (var change in args.Changes) changeData.Add(new TextChangeData(change.OldPosition, change.Delta));
			_bufferTextChangeHandler.OnTextChanged(changeData);
		}
	}
}