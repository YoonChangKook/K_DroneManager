using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneManager.UWB
{
    public struct Vector3
    {
        public double x;
        public double y;
        public double z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 zero
        {
            get
            {
                return new Vector3(0, 0, 0);
            }
        }
    };

    public abstract class Trilateration_Consts
    {
        public static readonly double MAX_ZERO = 0.001;
        public static readonly int ERR_TRIL_CONCENTRIC = 0;
        public static readonly int ERR_TRIL_COLINEAR_2SOLUTIONS = 1;
        public static readonly int ERR_TRIL_SQRTNEGNUMB = 3;
        public static readonly int TRIL_3SPHERES = 10;
        public static readonly int TRIL_4SPHERES = 11;
    }

    public abstract class Trilateration
    {
        public static Vector3 vdiff(Vector3 vector1, Vector3 vector2)
        {
            Vector3 result;
            result.x = vector1.x - vector2.x;
            result.y = vector1.y - vector2.y;
            result.z = vector1.z - vector2.z;
            return result;
        }

        public static Vector3 vsum(Vector3 vector1, Vector3 vector2)
        {
            Vector3 result;
            result.x = vector1.x + vector2.x;
            result.y = vector1.y + vector2.y;
            result.z = vector1.z + vector2.z;
            return result;
        }

        public static Vector3 vmul(Vector3 vector, double n)
        {
            Vector3 result;
            result.x = vector.x * n;
            result.y = vector.y * n;
            result.z = vector.z * n;
            return result;
        }

        public static Vector3 vdiv(Vector3 vector, double n)
        {
            Vector3 result;
            result.x = vector.x / n;
            result.y = vector.y / n;
            result.z = vector.z / n;
            return result;
        }

        public static double vdist(Vector3 vector1, Vector3 vector2)
        {
            double xd = vector1.x - vector2.x;
            double yd = vector1.y - vector2.y;
            double zd = vector1.z - vector2.z;
            return Math.Sqrt(xd * xd + yd * yd + zd * zd);
        }

        public static double vnorm(Vector3 vector)
        {
            return Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        }

        public static double dot(Vector3 vector1, Vector3 vector2)
        {
            return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
        }

        public static Vector3 cross(Vector3 vector1, Vector3 vector2)
        {
            Vector3 result;
            result.x = vector1.y * vector2.z - vector1.z * vector2.y;
            result.y = vector1.z * vector2.x - vector1.x * vector2.z;
            result.z = vector1.x * vector2.y - vector1.y * vector2.x;
            return result;
        }

        /* Intersecting a sphere sc with radius of r, with a line p1-p2.
         * Return zero if successful, negative error otherwise.
         * mu1 & mu2 are constant to find points of intersection.
        */
        public static int sphereline(Vector3 p1, Vector3 p2, Vector3 sc, double r, ref double mu1, ref double mu2)
        {
           double a,b,c;
           double bb4ac;
           Vector3 dp;

           dp.x = p2.x - p1.x;
           dp.y = p2.y - p1.y;
           dp.z = p2.z - p1.z;

           a = dp.x * dp.x + dp.y * dp.y + dp.z * dp.z;

           b = 2 * (dp.x * (p1.x - sc.x) + dp.y * (p1.y - sc.y) + dp.z * (p1.z - sc.z));

           c = sc.x * sc.x + sc.y * sc.y + sc.z * sc.z;
           c += p1.x * p1.x + p1.y * p1.y + p1.z * p1.z;
           c -= 2 * (sc.x * p1.x + sc.y * p1.y + sc.z * p1.z);
           c -= r * r;

           bb4ac = b * b - 4 * a * c;

           if (Math.Abs(a) == 0 || bb4ac < 0) {
              mu1 = 0;
              mu2 = 0;
              return -1;
           }

           mu1 = (-b + Math.Sqrt(bb4ac)) / (2 * a);
           mu2 = (-b - Math.Sqrt(bb4ac)) / (2 * a);

           return 0;
        }

        public static int trilateration(ref Vector3 result1,
                                ref Vector3 result2,
                                ref Vector3 bestSolution, 
                                Vector3 p1, double r1,
                                Vector3 p2, double r2,
                                Vector3 p3, double r3,
                                Vector3 p4, double r4)
        {
            Vector3 ex, ey, ez, t1, t2, t3;
            double h, i, j, x, y, z, t;
            double mu1 = 0, mu2 = 0, mu = 0;
            int result;

            ex = vdiff(p3, p1); // vector p13
            h = vnorm(ex); // scalar p13
            if (h <= Trilateration_Consts.MAX_ZERO)
            {
                /* p1 and p3 are concentric, not good to obtain a precise intersection point */
                //printf("concentric13 return -1\n");
                return Trilateration_Consts.ERR_TRIL_CONCENTRIC;
            }

            /* h = |p3 - p2|, ex = (p3 - p2) / |p3 - p2| */
            ex = vdiff(p3, p2); // vector p23
            h = vnorm(ex); // scalar p23
            if (h <= Trilateration_Consts.MAX_ZERO)
            {
                /* p2 and p3 are concentric, not good to obtain a precise intersection point */
                //printf("concentric23 return -1\n");
                return Trilateration_Consts.ERR_TRIL_CONCENTRIC;
            }

            /* h = |p2 - p1|, ex = (p2 - p1) / |p2 - p1| */
            ex = vdiff(p2, p1); // vector p12
            h = vnorm(ex); // scalar p12
            if (h <= Trilateration_Consts.MAX_ZERO)
            {
                /* p1 and p2 are concentric, not good to obtain a precise intersection point */
                //printf("concentric12 return -1\n");
                return Trilateration_Consts.ERR_TRIL_CONCENTRIC;
            }
            ex = vdiv(ex, h); // unit vector ex with respect to p1 (new coordinate system)

            /* t1 = p3 - p1, t2 = ex (ex . (p3 - p1)) */
            t1 = vdiff(p3, p1); // vector p13
            i = dot(ex, t1); // the scalar of t1 on the ex direction
            t2 = vmul(ex, i); // colinear vector to p13 with the length of i

            /* ey = (t1 - t2), t = |t1 - t2| */
            ey = vdiff(t1, t2); // vector t21 perpendicular to t1
            t = vnorm(ey); // scalar t21
            if (t > Trilateration_Consts.MAX_ZERO)
            {
                /* ey = (t1 - t2) / |t1 - t2| */
                ey = vdiv(ey, t); // unit vector ey with respect to p1 (new coordinate system)

                /* j = ey . (p3 - p1) */
                j = dot(ey, t1); // scalar t1 on the ey direction
            }
            else
                j = 0.0;

            /* Note: t <= maxzero implies j = 0.0. */
            if (Math.Abs(j) <= Trilateration_Consts.MAX_ZERO)
            {

                /* Is point p1 + (r1 along the axis) the intersection? */
                t2 = vsum(p1, vmul(ex, r1));
                if (Math.Abs(vnorm(vdiff(p2, t2)) - r2) <= Trilateration_Consts.MAX_ZERO &&
                    Math.Abs(vnorm(vdiff(p3, t2)) - r3) <= Trilateration_Consts.MAX_ZERO)
                {
                    /* Yes, t2 is the only intersection point. */
                    result1 = t2;
                    result2 = t2;
                    //return Trilateration_Consts.TRIL_3SPHERES;
                }

                /* Is point p1 - (r1 along the axis) the intersection? */
                t2 = vsum(p1, vmul(ex, -r1));
                if (Math.Abs(vnorm(vdiff(p2, t2)) - r2) <= Trilateration_Consts.MAX_ZERO &&
                    Math.Abs(vnorm(vdiff(p3, t2)) - r3) <= Trilateration_Consts.MAX_ZERO)
                {
                    /* Yes, t2 is the only intersection point. */
                    result1 = t2;
                    result2 = t2;
                    //return Trilateration_Consts.TRIL_3SPHERES;
                }
                /* p1, p2 and p3 are colinear with more than one solution */
                return Trilateration_Consts.ERR_TRIL_COLINEAR_2SOLUTIONS;
            }

            /* ez = ex x ey */
            ez = cross(ex, ey); // unit vector ez with respect to p1 (new coordinate system)

            x = (r1 * r1 - r2 * r2) / (2 * h) + h / 2;
            y = (r1 * r1 - r3 * r3 + i * i) / (2 * j) + j / 2 - x * i / j;
            z = r1 * r1 - x * x - y * y;
            if (z < -Trilateration_Consts.MAX_ZERO)
            {
                return Trilateration_Consts.ERR_TRIL_SQRTNEGNUMB;
            }
            if (z > 0.0)
                z = Math.Sqrt(z);
            else
                z = 0.0;

            /* t2 = p1 + x ex + y ey */
            t2 = vsum(p1, vmul(ex, x));
            t2 = vsum(t2, vmul(ey, y));

            /* result1 = p1 + x ex + y ey + z ez */
            result1 = vsum(t2, vmul(ez, z));

            /* result1 = p1 + x ex + y ey - z ez */
            result2 = vsum(t2, vmul(ez, -z));

            ex = vdiff(p4, p1);
            h = vnorm(ex);
            if (h <= Trilateration_Consts.MAX_ZERO)
                return Trilateration_Consts.TRIL_3SPHERES;

            ex = vdiff(p4, p2); // vector p24
            h = vnorm(ex); // scalar p24
            if (h <= Trilateration_Consts.MAX_ZERO)
                return Trilateration_Consts.TRIL_3SPHERES;
            /* h = |p4 - p3|, ex = (p4 - p3) / |p4 - p3| */
            ex = vdiff(p4, p3); // vector p34
            h = vnorm(ex); // scalar p34
            if (h <= Trilateration_Consts.MAX_ZERO)
                return Trilateration_Consts.TRIL_3SPHERES;

            // if sphere 4 is not concentric to any sphere, then best solution can be obtained
            /* find i as the distance of result1 to p4 */
            t3 = vdiff(result1, p4);
            i = vnorm(t3);
            /* find h as the distance of result2 to p4 */
            t3 = vdiff(result2, p4);
            h = vnorm(t3);

            if (i > h)
            {
                bestSolution = result1;
                result1 = result2;
                result2 = bestSolution;
            }

            int count4 = 0;
            double rr4 = r4;
            result = 1;
            /* intersect result1-result2 vector with sphere 4 */
            while (result != 0 && count4 < 10)
            {
                result = sphereline(result1, result2, p4, rr4, ref mu1, ref mu2);
                rr4 += 0.1;
                count4++;
            }

            if (result != 0)
            {
                /* No intersection between sphere 4 and the line with the gradient of result1-result2! */
                bestSolution = result1; // result1 is the closer solution to sphere 4
                //return ERR_TRIL_NOINTERSECTION_SPHERE4;
            }
            else
            {
                if (mu1 < 0 && mu2 < 0)
                {
                    /* if both mu1 and mu2 are less than 0 */
                    /* result1-result2 line segment is outside sphere 4 with no intersection */
                    if (Math.Abs(mu1) <= Math.Abs(mu2)) mu = mu1; else mu = mu2;
                    /* h = |result2 - result1|, ex = (result2 - result1) / |result2 - result1| */
                    ex = vdiff(result2, result1); // vector result1-result2
                    h = vnorm(ex); // scalar result1-result2
                    ex = vdiv(ex, h); // unit vector ex with respect to result1 (new coordinate system)
                    /* 50-50 error correction for mu */
                    mu = 0.5 * mu;
                    /* t2 points to the intersection */
                    t2 = vmul(ex, mu * h);
                    t2 = vsum(result1, t2);
                    /* the best solution = t2 */
                    bestSolution = t2;
                }
                else if ((mu1 < 0 && mu2 > 1) || (mu2 < 0 && mu1 > 1))
                {
                    /* if mu1 is less than zero and mu2 is greater than 1, or the other way around */
                    /* result1-result2 line segment is inside sphere 4 with no intersection */
                    if (mu1 > mu2) mu = mu1; else mu = mu2;
                    /* h = |result2 - result1|, ex = (result2 - result1) / |result2 - result1| */
                    ex = vdiff(result2, result1); // vector result1-result2
                    h = vnorm(ex); // scalar result1-result2
                    ex = vdiv(ex, h); // unit vector ex with respect to result1 (new coordinate system)
                    /* t2 points to the intersection */
                    t2 = vmul(ex, mu * h);
                    t2 = vsum(result1, t2);
                    /* vector t2-result2 with 50-50 error correction on the length of t3 */
                    t3 = vmul(vdiff(result2, t2), 0.5);
                    /* the best solution = t2 + t3 */
                    bestSolution = vsum(t2, t3);
                }
                else if (((mu1 > 0 && mu1 < 1) && (mu2 < 0 || mu2 > 1))
                      || ((mu2 > 0 && mu2 < 1) && (mu1 < 0 || mu1 > 1)))
                {
                    /* if one mu is between 0 to 1 and the other is not */
                    /* result1-result2 line segment intersects sphere 4 at one point */
                    if (mu1 >= 0 && mu1 <= 1) mu = mu1; else mu = mu2;
                    /* add or subtract with 0.5*mu to distribute error equally onto every sphere */
                    if (mu <= 0.5) mu -= 0.5 * mu; else mu -= 0.5 * (1 - mu);
                    /* h = |result2 - result1|, ex = (result2 - result1) / |result2 - result1| */
                    ex = vdiff(result2, result1); // vector result1-result2
                    h = vnorm(ex); // scalar result1-result2
                    ex = vdiv(ex, h); // unit vector ex with respect to result1 (new coordinate system)
                    /* t2 points to the intersection */
                    t2 = vmul(ex, mu * h);
                    t2 = vsum(result1, t2);
                    /* the best solution = t2 */
                    bestSolution = t2;
                }
                else if (mu1 == mu2)
                {
                    /* if both mu1 and mu2 are between 0 and 1, and mu1 = mu2 */
                    /* result1-result2 line segment is tangential to sphere 4 at one point */
                    mu = mu1;
                    /* add or subtract with 0.5*mu to distribute error equally onto every sphere */
                    if (mu <= 0.25) mu -= 0.5 * mu;
                    else if (mu <= 0.5) mu -= 0.5 * (0.5 - mu);
                    else if (mu <= 0.75) mu -= 0.5 * (mu - 0.5);
                    else mu -= 0.5 * (1 - mu);
                    /* h = |result2 - result1|, ex = (result2 - result1) / |result2 - result1| */
                    ex = vdiff(result2,result1); // vector result1-result2
                    h = vnorm(ex); // scalar result1-result2
                    ex = vdiv(ex, h); // unit vector ex with respect to result1 (new coordinate system)
                    /* t2 points to the intersection */
                    t2 = vmul(ex, mu * h);
                    t2 = vsum(result1, t2);
                    /* the best solution = t2 */
                    bestSolution = t2;
                }
                else
                {
                    /* if both mu1 and mu2 are between 0 and 1 */
                    /* result1-result2 line segment intersects sphere 4 at two points */
                    mu = mu1 + mu2;
                    /* h = |result2 - result1|, ex = (result2 - result1) / |result2 - result1| */
                    ex = vdiff(result2, result1); // vector result1-result2
                    h = vnorm(ex); // scalar result1-result2
                    ex = vdiv(ex, h); // unit vector ex with respect to result1 (new coordinate system)
                    /* 50-50 error correction for mu */
                    mu = 0.5 * mu;
                    /* t2 points to the intersection */
                    t2 = vmul(ex, mu * h);
                    t2 = vsum(result1, t2);
                    /* the best solution = t2 */
                    bestSolution = t2;
                }

            }

            return Trilateration_Consts.TRIL_4SPHERES;
            //return Trilateration_Consts.TRIL_3SPHERES;
        }

        public static int trilateration(ref Vector3 result1,
                                ref Vector3 result2,
                                Vector3 p1, double r1,
                                Vector3 p2, double r2,
                                Vector3 p3, double r3)
        {
            Vector3 ex, ey, ez, t1, t2;
            double h, i, j, x, y, z, t;

            ex = vdiff(p3, p1); // vector p13
            h = vnorm(ex); // scalar p13
            if (h <= Trilateration_Consts.MAX_ZERO)
            {
                /* p1 and p3 are concentric, not good to obtain a precise intersection point */
                //printf("concentric13 return -1\n");
                return Trilateration_Consts.ERR_TRIL_CONCENTRIC;
            }

            /* h = |p3 - p2|, ex = (p3 - p2) / |p3 - p2| */
            ex = vdiff(p3, p2); // vector p23
            h = vnorm(ex); // scalar p23
            if (h <= Trilateration_Consts.MAX_ZERO)
            {
                /* p2 and p3 are concentric, not good to obtain a precise intersection point */
                //printf("concentric23 return -1\n");
                return Trilateration_Consts.ERR_TRIL_CONCENTRIC;
            }

            /* h = |p2 - p1|, ex = (p2 - p1) / |p2 - p1| */
            ex = vdiff(p2, p1); // vector p12
            h = vnorm(ex); // scalar p12
            if (h <= Trilateration_Consts.MAX_ZERO)
            {
                /* p1 and p2 are concentric, not good to obtain a precise intersection point */
                //printf("concentric12 return -1\n");
                return Trilateration_Consts.ERR_TRIL_CONCENTRIC;
            }
            ex = vdiv(ex, h); // unit vector ex with respect to p1 (new coordinate system)

            /* t1 = p3 - p1, t2 = ex (ex . (p3 - p1)) */
            t1 = vdiff(p3, p1); // vector p13
            i = dot(ex, t1); // the scalar of t1 on the ex direction
            t2 = vmul(ex, i); // colinear vector to p13 with the length of i

            /* ey = (t1 - t2), t = |t1 - t2| */
            ey = vdiff(t1, t2); // vector t21 perpendicular to t1
            t = vnorm(ey); // scalar t21
            if (t > Trilateration_Consts.MAX_ZERO)
            {
                /* ey = (t1 - t2) / |t1 - t2| */
                ey = vdiv(ey, t); // unit vector ey with respect to p1 (new coordinate system)

                /* j = ey . (p3 - p1) */
                j = dot(ey, t1); // scalar t1 on the ey direction
            }
            else
                j = 0.0;

            /* Note: t <= maxzero implies j = 0.0. */
            if (Math.Abs(j) <= Trilateration_Consts.MAX_ZERO)
            {

                /* Is point p1 + (r1 along the axis) the intersection? */
                t2 = vsum(p1, vmul(ex, r1));
                if (Math.Abs(vnorm(vdiff(p2, t2)) - r2) <= Trilateration_Consts.MAX_ZERO &&
                    Math.Abs(vnorm(vdiff(p3, t2)) - r3) <= Trilateration_Consts.MAX_ZERO)
                {
                    /* Yes, t2 is the only intersection point. */
                    result1 = t2;
                    result2 = t2;
                    //return Trilateration_Consts.TRIL_3SPHERES;
                }

                /* Is point p1 - (r1 along the axis) the intersection? */
                t2 = vsum(p1, vmul(ex, -r1));
                if (Math.Abs(vnorm(vdiff(p2, t2)) - r2) <= Trilateration_Consts.MAX_ZERO &&
                    Math.Abs(vnorm(vdiff(p3, t2)) - r3) <= Trilateration_Consts.MAX_ZERO)
                {
                    /* Yes, t2 is the only intersection point. */
                    result1 = t2;
                    result2 = t2;
                    //return Trilateration_Consts.TRIL_3SPHERES;
                }
                /* p1, p2 and p3 are colinear with more than one solution */
                return Trilateration_Consts.ERR_TRIL_COLINEAR_2SOLUTIONS;
            }

            /* ez = ex x ey */
            ez = cross(ex, ey); // unit vector ez with respect to p1 (new coordinate system)

            x = (r1 * r1 - r2 * r2) / (2 * h) + h / 2;
            y = (r1 * r1 - r3 * r3 + i * i) / (2 * j) + j / 2 - x * i / j;
            z = r1 * r1 - x * x - y * y;
            if (z < -Trilateration_Consts.MAX_ZERO)
            {
                return Trilateration_Consts.ERR_TRIL_SQRTNEGNUMB;
            }
            if (z > 0.0)
                z = Math.Sqrt(z);
            else
                z = 0.0;

            /* t2 = p1 + x ex + y ey */
            t2 = vsum(p1, vmul(ex, x));
            t2 = vsum(t2, vmul(ey, y));

            /* result1 = p1 + x ex + y ey + z ez */
            result1 = vsum(t2, vmul(ez, z));

            /* result1 = p1 + x ex + y ey - z ez */
            result2 = vsum(t2, vmul(ez, -z));

            return Trilateration_Consts.TRIL_3SPHERES;
        }

        public static bool GetLocation(ref Vector3 bestSolution, 
                                        Dictionary<int, UWBAnchor> anchorArray, 
                                        int[] XZTri, int[] XYTri, int[] distanceArray)
        {
            Vector3 o1 = Vector3.zero;
            Vector3 o2 = Vector3.zero;
            Vector3 best = Vector3.zero;
            //int result = trilateration(ref o1, ref o2, ref best,
            //                            anchorArray[XZTri[0]].anchorPos, distanceArray[XZTri[0]] / 1000.0,
            //                            anchorArray[XZTri[1]].anchorPos, distanceArray[XZTri[1]] / 1000.0,
            //                            anchorArray[XZTri[2]].anchorPos, distanceArray[XZTri[2]] / 1000.0,
            //                            anchorArray[XZTri[3]].anchorPos, distanceArray[XZTri[3]] / 1000.0);
            int result = trilateration(ref o1, ref o2,
                                        anchorArray[XZTri[0]].anchorPos, distanceArray[XZTri[0]] / 1000.0,
                                        anchorArray[XZTri[1]].anchorPos, distanceArray[XZTri[1]] / 1000.0,
                                        anchorArray[XZTri[2]].anchorPos, distanceArray[XZTri[2]] / 1000.0);

            if (result == Trilateration_Consts.TRIL_3SPHERES)
            {
                //????
                if (o1.z < anchorArray[XZTri[0]].anchorPos.z)
                    bestSolution = o1;
                else
                    bestSolution = o2;
            }
            

            //result = trilateration(ref o1, ref o2, ref best, 
            //                        anchorArray[XYTri[0]].anchorPos, distanceArray[XYTri[0]] / 1000.0,
            //                        anchorArray[XYTri[1]].anchorPos, distanceArray[XYTri[1]] / 1000.0,
            //                        anchorArray[XYTri[2]].anchorPos, distanceArray[XYTri[2]] / 1000.0,
            //                        anchorArray[XYTri[3]].anchorPos, distanceArray[XYTri[3]] / 1000.0);
            result = trilateration(ref o1, ref o2,
                           anchorArray[XYTri[0]].anchorPos, distanceArray[XYTri[0]] / 1000.0,
                           anchorArray[XYTri[1]].anchorPos, distanceArray[XYTri[1]] / 1000.0,
                           anchorArray[XYTri[2]].anchorPos, distanceArray[XYTri[2]] / 1000.0);

            if (result == Trilateration_Consts.TRIL_3SPHERES)
            {
                //?????
                if (o1.z < anchorArray[XYTri[0]].anchorPos.z)
                    bestSolution.y = o1.y;
                else
                    bestSolution.y = o2.y;

                return true;
            }

            return false;
        }
    }
}
