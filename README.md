# Animating Unity UI auto-layouts
This project exists to show some examples of how to animate Unity UI components when they are driven by the auto-layout system. Ordinarily, it's impossible to animate auto-layouts because their `RectTransforms` are constantly being overwritten by whichever `LayoutGroup` is driving them. This project demonstrates a way around that problem, and allows you to use regular Unity animation clips to animate slide-ins and fold-ins.

## Caveats
Animating with the built-in Unity animation clip system will create tons of garbage keyframes if the auto-layout system is active while you're animating. I mostly animate with the objects I'm animating disabled so they don't trigger the auto-layout functions.

I haven't been able to figure out how to create an effective two-dimensional slide-in, e.g. slide in from the top left. Unfortunately, it doesn't seem possible to tween the `Flexible` properties effectively, so you can't really use them.

## Goals
Ultimately, I'd like to have as much layout flexibility as the CSS Box Model. The [Unity UI Extensions](https://bitbucket.org/ddreaper/unity-ui-extensions) project is a good place to look for some of that functionality.

## How to use
Download this example project and take a look at how the components are put together in the included test scenes.

### Fold-in animations
Animations where the object is being laid-out while animating (so that child objects are constantly updating position and size) are possible if you use the default `LayoutGroup` components while animating the new `AnimatableLayoutElement`.

### Slide-in animations
Animations where the object is laid-out at "final" dimensions, and is then unmasked, are possible if you use the new `AnimatableLayout` components and disable their `active` field while animating.
