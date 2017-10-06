using InstagramWrapper.Api;
using InstagramWrapper.DataModel;
using System;

namespace InstagramWrapper.Endpoints
{
    public class LocationService : EndpointServiceBase
    {
        private const string LocationByIdApi = "https://api.instagram.com/v1/locations/{0}?access_token={1}";
        private const string SearchLocationApi = "https://api.instagram.com/v1/locations/search?lat={0}&lng={1}&distance={2}&access_token={3}";

        public LocationService(string accessToken)
        {
            AccessToken = accessToken;
        }

        public Uri LocationByIdApiUri(string locationId)
        {
            return new Uri(string.Format(LocationByIdApi, locationId, AccessToken));
        }
        public Uri SearchLocationApiUri(string latitude, string longitude, string distance)
        {
            return new Uri(string.Format(SearchLocationApi, latitude, longitude, distance, AccessToken));
        }

        /// <summary>
        /// Get information about a location.
        /// </summary>
        /// <param name="locationId">Location ID.</param>
        /// <returns>Information of a location</returns>
        public Envelope<Location> GetLocationById(string locationId)
        {
            return new InstagramApiService<Location>(this.LocationByIdApiUri(locationId)).Get();
        }
        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="latitude">Latitude of the center search coordinate. If used, longitude is required.</param>
        /// <param name="longitude">Longitude of the center search coordinate. If used, latitude is required.</param>
        /// <param name="distance">Default is 500m (distance=500), max distance is 750m.</param>
        /// <returns>List of locations</returns>
        public Envelope<Location[]> SearchLocations(float latitude, float longitude, int distance = 500)
        {
            return new InstagramApiService<Location[]>(this.SearchLocationApiUri(latitude.ToString(), longitude.ToString(), distance.ToString())).Get();
        }
    }
}
