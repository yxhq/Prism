﻿using System;
using Prism.Navigation;
using Prism.Regions.Navigation;

namespace Prism.Regions
{
    /// <summary>
    /// NavigationExtensions for the <see cref="IRegionManager" />
    /// </summary>
    public static class IRegionManagerExtensions
    {
        /// <summary>
        /// Initiates navigation to the target specified by the <paramref name="target"/>.
        /// </summary>
        /// <param name="regionManager">The navigation object.</param>
        /// <param name="regionName">The name of the Region to navigate to.</param>
        /// <param name="target">The navigation target</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, string target)
        {
            RequestNavigate(regionManager, regionName, target, nr => { });
        }

        /// <summary>
        /// Initiates navigation to the target specified by the <paramref name="target"/>.
        /// </summary>
        /// <param name="regionManager">The navigation object.</param>
        /// <param name="regionName">The name of the Region to navigate to.</param>
        /// <param name="target">The navigation target</param>
        /// <param name="navigationCallback">The callback executed when the navigation request is completed.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, string target, Action<IRegionNavigationResult> navigationCallback)
        {
            if (regionManager == null)
                throw new ArgumentNullException(nameof(regionManager));

            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var targetUri = new Uri(target, UriKind.RelativeOrAbsolute);

            regionManager.RequestNavigate(regionName, targetUri, navigationCallback);
        }

        /// <summary>
        /// Initiates navigation to the target specified by the <see cref="Uri"/>.
        /// </summary>
        /// <param name="regionManager">The navigation object.</param>
        /// <param name="regionName">The name of the Region to navigate to.</param>
        /// <param name="target">The navigation target</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, Uri target)
        {
            if (regionManager == null)
                throw new ArgumentNullException(nameof(regionManager));

            regionManager.RequestNavigate(regionName, target, nr => { });
        }

        /// <summary>
        /// Initiates navigation to the target specified by the <paramref name="target"/>.
        /// </summary>
        /// <param name="regionManager">The navigation object.</param>
        /// <param name="regionName">The name of the Region to navigate to.</param>
        /// <param name="target">The navigation target</param>
        /// <param name="navigationCallback">The callback executed when the navigation request is completed.</param>
        /// <param name="regionParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, string target, Action<IRegionNavigationResult> navigationCallback, INavigationParameters regionParameters)
        {
            if (regionManager == null)
                throw new ArgumentNullException(nameof(regionManager));

            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var targetUri = new Uri(target, UriKind.RelativeOrAbsolute);

            regionManager.RequestNavigate(regionName, targetUri, navigationCallback, regionParameters);
        }

        /// <summary>
        /// Initiates navigation to the target specified by the <paramref name="target"/>.
        /// </summary>
        /// <param name="regionManager">The RegionManager object.</param>
        /// <param name="regionName">The name of the Region to navigate to.</param>
        /// <param name="target">A Uri that represents the target where the region will navigate.</param>
        /// <param name="regionParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, Uri target, INavigationParameters regionParameters)
        {
            if (regionManager == null)
                throw new ArgumentNullException(nameof(regionManager));

            regionManager.RequestNavigate(regionName, target, nr => { }, regionParameters);
        }

        /// <summary>
        /// Initiates navigation to the target specified by the <paramref name="target"/>.
        /// </summary>
        /// <param name="regionManager">The RegionManager object.</param>
        /// <param name="regionName">The name of the Region to navigate to.</param>
        /// <param name="target">A string that represents the target where the region will navigate.</param>
        /// <param name="regionParameters">An instance of NavigationParameters, which holds a collection of object parameters.</param>
        public static void RequestNavigate(this IRegionManager regionManager, string regionName, string target, INavigationParameters regionParameters)
        {
            if (regionManager == null)
                throw new ArgumentNullException(nameof(regionManager));

            if (target == null)
                throw new ArgumentNullException(nameof(target));

            regionManager.RequestNavigate(regionName, new Uri(target, UriKind.RelativeOrAbsolute), nr => { }, regionParameters);
        }
    }
}
