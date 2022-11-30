namespace CloudComputingAPI.Repositories.Impl
{
    public class TMDbRepository : ITMDbRepository
    {
        private string apiKey = "ac1ccaf7cc1c015abd2c2cddca72cb16";

        private string UriRootDiscoverMovie = "https://api.themoviedb.org/3/discover/movie";

        private string language = "language=en-US";

        private string sortBy = "sort_by=vote_average.desc";

        private string includeAdult = "include_adult=false";

        private string includeVideo = "include_video=false";

        private string releaseDateStart = "";

        private string releaseDateEnd = "";

        private string page = "";

        private string UrlTopRated70s = "https://api.themoviedb.org/3/discover/movie?api_key=ac1ccaf7cc1c015abd2c2cddca72cb16&language=en-US&sort_by=vote_average.desc&include_adult=false&include_video=false&primary_release_date.gte=1970-01-01&primary_release_date.lte=1979-12-31&vote_count.gte=300&vote_average.lte=10&with_runtime.gte=0&with_runtime.lte=400&page=1";

        private string UrlTopRated80s = "https://api.themoviedb.org/3/discover/movie?api_key=ac1ccaf7cc1c015abd2c2cddca72cb16&language=en-US&sort_by=vote_average.desc&include_adult=false&include_video=false&primary_release_date.gte=1980-01-01&primary_release_date.lte=1989-12-31&vote_count.gte=300&vote_average.lte=10&with_runtime.gte=0&with_runtime.lte=400&page=1";

        private string UrlTopRated90s = "https://api.themoviedb.org/3/discover/movie?api_key=ac1ccaf7cc1c015abd2c2cddca72cb16&language=en-US&sort_by=vote_average.desc&include_adult=false&include_video=false&primary_release_date.gte=1990-01-01&primary_release_date.lte=1999-12-31&vote_count.gte=300&vote_average.lte=10&with_runtime.gte=0&with_runtime.lte=400&page=1";

        private string UrlTopRated20002009 = "https://api.themoviedb.org/3/discover/movie?api_key=ac1ccaf7cc1c015abd2c2cddca72cb16&language=en-US&sort_by=vote_average.desc&include_adult=false&include_video=false&primary_release_date.gte=2000-01-01&primary_release_date.lte=2009-12-31&vote_count.gte=300&vote_average.lte=10&with_runtime.gte=0&with_runtime.lte=400&page=1";

        private string UrlTopRated20102019 = "https://api.themoviedb.org/3/discover/movie?api_key=ac1ccaf7cc1c015abd2c2cddca72cb16&language=en-US&sort_by=vote_average.desc&include_adult=false&include_video=false&primary_release_date.gte=2010-01-01&primary_release_date.lte=2019-12-31&vote_count.gte=300&vote_average.lte=10&with_runtime.gte=0&with_runtime.lte=400&page=1";


    }
}
