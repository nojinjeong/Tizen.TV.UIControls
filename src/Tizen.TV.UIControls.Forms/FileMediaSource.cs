﻿/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Xamarin.Forms;

namespace Tizen.TV.UIControls.Forms
{
    [TypeConverter(typeof(FileMediaSourceConverter))]
    public sealed class FileMediaSource : MediaSource
    {
        public static readonly BindableProperty FileProperty = BindableProperty.Create("File", typeof(string), typeof(FileMediaSource), default(string));

        public string File
        {
            get { return (string)GetValue(FileProperty); }
            set { SetValue(FileProperty, value); }
        }

        public override string ToString()
        {
            return $"File: {File}";
        }

        public static implicit operator FileMediaSource(string file)
        {
            return (FileMediaSource)FromFile(file);
        }

        public static implicit operator string(FileMediaSource file)
        {
            return file?.File;
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            if (propertyName == FileProperty.PropertyName)
                OnSourceChanged();
            base.OnPropertyChanged(propertyName);
        }
    }
}