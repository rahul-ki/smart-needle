pragma solidity ^0.4.15;

contract Vaccination {

   mapping(uint => IoTData[]) vaccineData;
    
    struct IoTData {
        uint timestamp;
        uint temperature;
        uint long;
        uint lat;
    }
    
    event NewDetails(uint _vaccineID, uint timestamp, uint temperature, uint long, uint lat);
    
    function addDetails (uint _vaccineID, uint _temperature, uint _long, uint _lat) public {
        IoTData memory data = IoTData(now, _temperature, _long, _lat);
        vaccineData[_vaccineID].push(data);
        emit NewDetails(_vaccineID, now, _temperature, _long, _lat);
    }
}
