// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using Xenko.Core.Assets.Editor.ViewModel;
using Xenko.Core.Annotations;
using Xenko.Core.Extensions;
using TreeView = Xenko.Core.Presentation.Controls.TreeView;

namespace Xenko.Core.Assets.Editor.Extensions
{
    public static class ControlExtensions
    {
        public static void ExpandSessionObjects([NotNull] this TreeView treeView, List<SessionObjectViewModel> sessionObjects)
        {
            treeView.Dispatcher.BeginInvoke(new Action(() =>
            {
                try
                {
                    var shouldStop = true;
                    foreach (var sessionObject in sessionObjects.ToList())
                    {
                        var item = treeView.GetTreeViewItemFor(sessionObject);
                        if (item == null)
                            continue;

                        item.IsExpanded = true;
                        sessionObjects.Remove(sessionObject);
                        shouldStop = false;
                    }

                    if (!shouldStop && sessionObjects.Count > 0)
                        ExpandSessionObjects(treeView, sessionObjects);

                }
                catch (Exception e)
                {
                    e.Ignore();
                }

            }), DispatcherPriority.ApplicationIdle);
        }

        [CanBeNull]
        public static string GetSessionObjectPath([NotNull] this TreeView treeView, SessionObjectViewModel sessionObject)
        {
            var item = treeView.GetTreeViewItemFor(sessionObject);
            if (item == null)
                return null;

            var path = "";
            while (item != null)
            {
                sessionObject = item.DataContext as SessionObjectViewModel;
                if (sessionObject == null)
                    return null;

                path = sessionObject.Name + '/' + path;
                item = item.ParentTreeViewItem;
            }
            return path;
        }
    }
}
