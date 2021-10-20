#include"loadPointCloud.h"
#include <pcl/point_types.h> 
#include <pcl/io/ply_io.h>

extern "C"
{
    int readPointCloudFile(float* voPoints)
    {
        pcl::PointCloud<pcl::PointXYZ>::Ptr cloud(new pcl::PointCloud<pcl::PointXYZ>);
        if (pcl::io::loadPLYFile<pcl::PointXYZ>("E:\\fish.ply", *cloud) == -1)
        {
            return 0;
        }
        for (size_t i = 0; i < 3*cloud->points.size(); i += 3)
        {
            voPoints[i] = cloud->points[i/3].x;
            voPoints[i + 1] = cloud->points[i/3].y;
            voPoints[i + 2] = cloud->points[i/3].z;
        }
        return cloud->points.size();
    }
}
