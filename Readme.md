# Orchard Read-only Readme



## Project Description

You can set an Orchard site to read-only mode with this module as it can prevent content items from being saved.


## Features

- Can set an Orchard site to read-only by preventing content items from being saved
- When in read-only a validation error is displayed and the item can be re-saved once the site is out of read-only state
- State can be set from the dashboard or from the command line
- The message displayed is customizable


## Documentation

This modules gives you an option to set your Orchard site into read-only mode. Read-only mode is useful if you want to temporarily content-freeze your site (only advised for a very short time).

When read-only no content item (except for site settings) can be saved as saving will fail with a validation error. The error message displayed is customizable.

You can edit settings from under site settings and also you can set the mode of the site from the command line with the readonly set/reset/toggle commands.

Read-only is part of the [Lombiq Hosting Suite](http://dotnest.com/knowledge-base/topics/lombiq-hosting-suite), a suite of modules making Orchard able to scale better, more fault-tolerant, and have improved maintainability.

The module's source is available in two public source repositories, automatically mirrored in both directions with [Git-hg Mirror](https://githgmirror.com):

- [https://bitbucket.org/Lombiq/orchard-read-only](https://bitbucket.org/Lombiq/orchard-read-only) (Mercurial repository)
- [https://github.com/Lombiq/Orchard-Read-only](https://github.com/Lombiq/Orchard-Read-only) (Git repository)

Bug reports, feature requests and comments are warmly welcome, **please do so via GitHub**.
Feel free to send pull requests too, no matter which source repository you choose for this purpose.

This project is developed by [Lombiq Technologies Ltd](http://lombiq.com/). Commercial-grade support is available through Lombiq.