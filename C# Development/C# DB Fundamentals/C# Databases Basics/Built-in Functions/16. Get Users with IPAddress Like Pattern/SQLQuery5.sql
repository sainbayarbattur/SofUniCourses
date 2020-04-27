SELECT Username, IpAddress
FROM Users
WHERE SUBSTRING(LEFT(IpAddress, 4), 4, 1) = '.'
AND SUBSTRING(RIGHT(IpAddress, 3), 1, 3) NOT LIKE('%.%')
AND SUBSTRING(LEFT(IpAddress, 5), 5, 1) = '1'
ORDER BY Username