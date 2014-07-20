﻿using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Common.IO
{
    /// <summary>
    /// Contains extension methods for working with directories.
    /// </summary>
    public static class DirectoryExtensions
    {
        /// <summary>
        /// Deletes the specified directories.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="directories">The directory paths.</param>
        /// <param name="recursive">Will perform a recursive delete if set to <c>true</c>.</param>
        [CakeMethodAlias]
        public static void DeleteDirectories(this ICakeContext context, IEnumerable<DirectoryPath> directories, bool recursive = true)
        {
            foreach (var directory in directories)
            {
                DeleteDirectory(context, directory, recursive);
            }
        }

        /// <summary>
        /// Deletes the specified directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The directory path.</param>
        /// <param name="recursive">Will perform a recursive delete if set to <c>true</c>.</param>
        [CakeMethodAlias]
        public static void DeleteDirectory(this ICakeContext context, DirectoryPath path, bool recursive = false)
        {
            DirectoryDeleter.Delete(context, path, recursive);
        }

        /// <summary>
        /// Cleans the directories matching the specified pattern.
        /// Cleaning the directory will remove all it's content but not the directory iteself.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="pattern">The pattern to match.</param>
        [CakeMethodAlias]
        public static void CleanDirectories(this ICakeContext context, string pattern)
        {
            var directories = context.GetDirectories(pattern);
            CleanDirectories(context, directories);
        }

        /// <summary>
        /// Cleans the specified directories.
        /// Cleaning a directory will remove all it's content but not the directory iteself.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="directories">The directory paths.</param>
        [CakeMethodAlias]
        public static void CleanDirectories(this ICakeContext context, IEnumerable<DirectoryPath> directories)
        {
            foreach (var directory in directories)
            {
                CleanDirectory(context, directory);
            }
        }

        /// <summary>
        /// Cleans the specified directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The directory path.</param>
        [CakeMethodAlias]
        public static void CleanDirectory(this ICakeContext context, DirectoryPath path)
        {
            DirectoryCleaner.Clean(context, path);
        }

        /// <summary>
        /// Creates the specified directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The directory path.</param>
        [CakeMethodAlias]
        public static void CreateDirectory(this ICakeContext context, DirectoryPath path)
        {
            DirectoryCreator.Create(context, path);
        }
    }
}