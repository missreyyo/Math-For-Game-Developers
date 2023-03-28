
# **Bézier  Curves**
It was the best topic for me while I was learning math for developing game: Bézier curves. We can make curves with lines. How can we make bezier curves?
#
## Linear Interpolation (Lerp)
#
Let say we have two points P0 and P1 connected by line. And we have a third point between these point. The position of this point could be described by what is called a t value. t value is between 0 -1. When t value is equal to the 0, the point becomes P0. When t value is equal to the 1, the point becomes P1. This function is called linear interpolation or lerp for short. This function seems like that: 
[First example:](https://www.jasondavies.com/animated-bezier/)


> Mathematically we can write  = (1-t)P0 + tP1

> Also Unity have lerp function.  
funciton = lerp(P0, P1, t);
# 
## Quadratic Béziers
#
These are the real Bezier curves. It will occur when we add P2 as a third point. Now we have 3 point: P0, P1 and P2. We now have two interpolated points one on each line segment lerping on their respective line based on the same t value we saw earlier. If we connect these two interpolated points with another line segment. Then if we add a point on that line that also lerps based on the same t value. We will observe that the point we put last creates a curve. This path is quadratic bezier curve. This function seems like that:
[Second example](https://www.jasondavies.com/animated-bezier/)

When I see that firstly, I shocked. I realized that there are many things that can be done in Unity using math.

:blush:







